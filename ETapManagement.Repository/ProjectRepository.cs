using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public ResponseMessage CreateProject (ProjectDetail projectDetail) {
            try {
                if (_context.Project.Where (x => x.Name == projectDetail.Name && x.IsDelete == false).Count () > 0) {
                    throw new ValueNotFoundException ("Project  Name already exist.");
                }
                ResponseMessage responseMessage = new ResponseMessage ();
                Project project = _mapper.Map<Project> (projectDetail);
                _context.Project.Add (project);
                _context.SaveChanges ();

                //Add the site location
                if (projectDetail.ProjectSiteLocationDetails.Any ()) {
                    foreach (var item in projectDetail.ProjectSiteLocationDetails) {
                        ProjectSitelocation projectSitelocation = new ProjectSitelocation ();
                        projectSitelocation.Name = item.Name;
                        projectSitelocation.ProjectId = project.Id;
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

        public List<Code> GetProjectCodeList()
        {
            try
            {
                List<Code> result = new List<Code>();
                var projects = _context.Project.Where(x => x.IsDelete == false).ToList();
                foreach(var item in projects)
                {
                    result.Add(new Code()
                    {
                        Id = item.Id,
                        Name = item.ProjCode
                    });
                }
                 
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProjectDetail> GetProjectDetails()
        {
            try
            {
                List<ProjectDetail> result = new List<ProjectDetail>();
                var projects = _context.Project.Where(x => x.IsDelete == false)
                    .Include(s => s.ProjectSitelocation).ToList();
                result = _mapper.Map<List<ProjectDetail>>(projects);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ProjectDetail GetProjectDetailsById (int id) {
            try {
                ProjectDetail result = new ProjectDetail ();
                var project = _context.Project.Where (x => x.Id == id && x.IsDelete == false)
                    .Include(s => s.ProjectSitelocation).FirstOrDefault ();
                result = _mapper.Map<ProjectDetail> (project);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public ResponseMessage UpdateProject (ProjectDetail projectDetail, int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            try {
                var project = _context.Project.Where (x => x.Id == id && x.IsDelete == false).FirstOrDefault ();
                if (project != null) {
                    if (_context.Project.Where (x => x.Name == project.Name && x.Id != id && x.IsDelete == false).Count () > 0) {
                        throw new ValueNotFoundException ("Project Name already exist.");
                    } else {
                        project.Name = projectDetail.Name;
                        project.ProjCode = projectDetail.ProjCode;
                        project.Area = projectDetail.Area;
                        project.IcId = projectDetail.ICId;
                        project.BuId = projectDetail.BUId;
                        project.SegmentId = projectDetail.SegmentId;
                        project.CreatedBy = projectDetail.CreatedBy;
                        project.CreatedAt = projectDetail.CreatedAt;
                        project.UpdatedBy = projectDetail.UpdatedBy;
                        project.UpdatedAt = projectDetail.UpdatedtAt;

                        var projectLocations = _context.ProjectSitelocation.Where (x => x.ProjectId == project.Id).ToList ();
                        var addedSiteLocations = projectDetail.ProjectSiteLocationDetails.Where (x => !projectLocations.Any (p => p.Id == x.Id)).ToList ();
                        var deletedSiteLocations = projectLocations.Where (x => !projectDetail.ProjectSiteLocationDetails.Any (p => p.Id == x.Id)).ToList ();
                        var updatedSiteLocations = projectDetail.ProjectSiteLocationDetails.Where (x => projectLocations.Any (p => p.Id == x.Id)).ToList ();

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
                            Message = string.Format ("Project Updated Successfully {0}", projectDetail.Name),
                            CreatedAt = DateTime.Now,
                            CreatedBy = project.CreatedBy
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