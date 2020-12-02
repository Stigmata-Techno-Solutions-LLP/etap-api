using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain;
using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETapManagement.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public ProjectRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo)
        {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }
        public ResponseMessage CreateProject(ProjectDetail projectDetail)
        {
            try
            {
                ResponseMessage responseMessage = new ResponseMessage();
                Project project = _mapper.Map<Project>(projectDetail);
                _context.Project.Add(project);
                _context.SaveChanges();
                responseMessage.Message = "Project created sucessfully";
                return responseMessage;
            }
            catch(Exception ex)
            {
                throw ex;
            }
             
        }

        public ResponseMessage DeleteProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public List<ProjectDetail> GetProjectDetails()
        {
            throw new NotImplementedException();
        }

        public ProjectDetail GetProjectDetailsById(int projectId)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage UpdateProject(ProjectDetail projectDetail,int projectId)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            try
            {
                var project = _context.Project.Where(x => x.Id == projectId && x.IsDelete == false).FirstOrDefault();
                if (project != null)
                {
                     
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

                        _context.SaveChanges();

                        AuditLogs audit = new AuditLogs()
                        {
                            Action = "Project",
                            Message = string.Format("Update Project  Succussfully {0}", projectDetail.Name),
                            CreatedAt = DateTime.Now,
                            CreatedBy = project.CreatedBy
                        };
                        _commonRepo.AuditLog(audit);
                        return responseMessage = new ResponseMessage()
                        {
                            Message = "Project updated successfully.",

                        };
                     
                }
                else
                {
                    throw new ValueNotFoundException("Project not available.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
