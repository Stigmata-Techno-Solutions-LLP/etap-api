using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.Service
{
    public class ProjectService : IProjectService
    {
        IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public ResponseMessage CreateProject(ProjectDetail projectDetail)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _projectRepository.CreateProject(projectDetail);
            return responseMessage;
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

        public ResponseMessage UpdateProject(ProjectDetail projectDetail, int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
