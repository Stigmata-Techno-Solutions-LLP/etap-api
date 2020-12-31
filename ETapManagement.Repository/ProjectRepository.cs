using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Text;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore;

namespace ETapManagement.Repository {
    public class ProjectRepository : IProjectRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public ProjectRepository (ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

        public ResponseMessage CreateProject (AddProject project) {
            try {
                if (_context.Project.Where (x => x.Name == project.Name && x.IsDelete == false).Count () > 0) {
                    throw new ValueNotFoundException ("Project  Name already exist.");
                }
                int projCount = _context.Project.Count () + 1;
                string projCode = constantVal.ProjCodePrefix + projCount.ToString ().PadLeft (6, '0');
                ResponseMessage responseMessage = new ResponseMessage ();
                Project projectDB = _mapper.Map<Project> (project);
                project.ProjCode = projCode;
                _context.Project.Add (projectDB);
                _context.SaveChanges ();

                //Add the site location
                if (project.ProjectSiteLocationDetails.Any ()) {
                    foreach (var item in project.ProjectSiteLocationDetails) {
                        ProjectSitelocation projectSitelocation = new ProjectSitelocation ();
                        projectSitelocation.Name = item.Name;
                        projectSitelocation.ProjectId = projectDB.Id;
                        _context.ProjectSitelocation.Add (projectSitelocation);
                    }

                }
                _context.SaveChanges ();
                responseMessage.Message = "Project created sucessfully";
                return responseMessage;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage DeleteProject (int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {

                var project = _context.Project.Where (x => x.Id == id && x.IsDelete == false).FirstOrDefault ();
                if (project == null) throw new ValueNotFoundException ("Project Id doesnt exist.");
                project.IsDelete = true;
                _context.SaveChanges ();
                AuditLogs audit = new AuditLogs () {
                    Action = "Project",
                    Message = string.Format ("Project Deleted  Successfully {0}", project.Id),
                    CreatedAt = DateTime.Now,
                };
                _commonRepo.AuditLog (audit);
                return responseMessage = new ResponseMessage () {
                    Message = "Project deleted successfully."
                };
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<Code> GetProjectCodeList () {
            try {
                List<Code> result = new List<Code> ();
                var projects = _context.Project.Where (x => x.IsDelete == false).ToList ();
                foreach (var item in projects) {
                    result.Add (new Code () {
                        Id = item.Id,
                            Name = item.ProjCode
                    });
                }
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public List<ProjectDetail> GetProjectDetails () {
            try {
                List<ProjectDetail> result = new List<ProjectDetail> ();
                var projects = _context.Project.Where (x => x.IsDelete == false)
                    .Include (s => s.ProjectSitelocation)
                    .Include (s => s.Ic)
                    .Include (s => s.Bu).ToList ();
                result = _mapper.Map<List<ProjectDetail>> (projects);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ProjectDetail GetProjectDetailsById (int id) {
            try {
                ProjectDetail result = new ProjectDetail ();
                var project = _context.Project.Where (x => x.Id == id && x.IsDelete == false)
                    .Include (s => s.ProjectSitelocation)
                  
                    .Include (s => s.Ic)
                    .Include (s => s.Bu).FirstOrDefault ();
                result = _mapper.Map<ProjectDetail> (project);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage UpdateProject (AddProject project, int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                var projectDB = _context.Project.Where (x => x.Id == id && x.IsDelete == false).FirstOrDefault ();
                if (projectDB != null) {
                    if (_context.Project.Where (x => x.Name == project.Name && x.Id != id && x.IsDelete == false).Count () > 0) {
                        throw new ValueNotFoundException ("Project Name already exist.");
                    } else {
                        projectDB.Name = project.Name;
                        projectDB.Area = project.Area;
                        projectDB.IcId = project.ICId;
                        projectDB.BuId = project.BUId;
                        projectDB.EdrcCode = project.EDRCCode;
                        projectDB.JobCode = project.JobCode;
                        projectDB.CreatedBy = 1; //TODO
                        projectDB.CreatedAt = DateTime.Now;
                        projectDB.UpdatedBy = 1; //TODO
                        projectDB.UpdatedAt = DateTime.Now;

                        var projectLocations = _context.ProjectSitelocation.Where (x => x.ProjectId == project.Id).ToList ();
                        var addedSiteLocations = project.ProjectSiteLocationDetails.Where (x => !projectLocations.Any (p => p.Id == x.Id)).ToList ();
                        var deletedSiteLocations = projectLocations.Where (x => !project.ProjectSiteLocationDetails.Any (p => p.Id == x.Id)).ToList ();
                        var updatedSiteLocations = project.ProjectSiteLocationDetails.Where (x => projectLocations.Any (p => p.Id == x.Id)).ToList ();

                        //add Project site Location
                        if (addedSiteLocations.Any ()) {
                            foreach (var item in addedSiteLocations) {
                                ProjectSitelocation projectSitelocation = new ProjectSitelocation ();
                                projectSitelocation.Name = item.Name;
                                _context.ProjectSitelocation.Add (projectSitelocation);
                            }
                        }

                        //delete Project site Location
                        if (deletedSiteLocations.Any ()) {
                            foreach (var item in deletedSiteLocations) {
                                _context.ProjectSitelocation.Remove (item);
                            }

                        }

                        //update Project site Location
                        if (updatedSiteLocations.Any ()) {
                            foreach (var item in updatedSiteLocations) {
                                ProjectSitelocation projectSitelocation = _context.ProjectSitelocation.Where (x => x.Id == item.Id).FirstOrDefault ();
                                projectSitelocation.Name = item.Name;

                            }
                        }
                        _context.SaveChanges ();
                        AuditLogs audit = new AuditLogs () {
                            Action = "Project",
                            Message = string.Format ("Project Updated Successfully {0}", project.Name),
                            CreatedAt = DateTime.Now,
                            CreatedBy = 1 //TODO
                        };
                        _commonRepo.AuditLog (audit);
                        return responseMessage = new ResponseMessage () {
                            Message = "Project updated successfully.",

                        };
                    }
                } else {
                    throw new ValueNotFoundException ("Project not available.");
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}