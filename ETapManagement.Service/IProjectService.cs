using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IProjectService {
        public ResponseMessage CreateProject (ProjectDetail projectDetail);
        public ResponseMessage UpdateProject (ProjectDetail projectDetail, int id);
        public ResponseMessage DeleteProject (int id);
        public List<ProjectDetail> GetProjectDetails ();
        public ProjectDetail GetProjectDetailsById (int id);
        public List<Code> GetProjectCodeList();
    }
}