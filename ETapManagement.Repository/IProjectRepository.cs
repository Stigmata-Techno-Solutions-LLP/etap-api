using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {
    public interface IProjectRepository {
        public ResponseMessage CreateProject (AddProject project);
        public ResponseMessage UpdateProject (AddProject project, int id);
        public ResponseMessage DeleteProject (int id);
        public List<ProjectDetail> GetProjectDetails ();
        public ProjectDetail GetProjectDetailsById (int id);
        public List<Code> GetProjectCodeList ();
    }
}