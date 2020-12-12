using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public class ProjectService : IProjectService {
        IProjectRepository _projectRepository;

        public ProjectService (IProjectRepository projectRepository) {
            _projectRepository = projectRepository;
        }

        public ResponseMessage CreateProject (ProjectDetail projectDetail) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _projectRepository.CreateProject (projectDetail);
            return responseMessage;
        }

        public ResponseMessage DeleteProject (int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _projectRepository.DeleteProject (id);
            return responseMessage;
        }

        public List<ProjectDetail> GetProjectDetails () {
            List<ProjectDetail> projectDetails = _projectRepository.GetProjectDetails ();
            return projectDetails;
        }

        public ProjectDetail GetProjectDetailsById (int id) {
            ProjectDetail projectDetail = _projectRepository.GetProjectDetailsById (id);
            return projectDetail;
        }

        public ResponseMessage UpdateProject (ProjectDetail projectDetail, int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _projectRepository.UpdateProject (projectDetail, id);
            return responseMessage;

        }
        public List<Code> GetProjectCodeList()
        {
            List<Code> codes = _projectRepository.GetProjectCodeList();
            return codes;
        }
    }
}