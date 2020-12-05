﻿using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.Repository
{
    public interface IProjectRepository
    {
        public ResponseMessage CreateProject(ProjectDetail projectDetail);
        public ResponseMessage UpdateProject(ProjectDetail projectDetail, int id);
        public ResponseMessage DeleteProject(int id);
        public List<ProjectDetail> GetProjectDetails();
        public ProjectDetail GetProjectDetailsById(int id);
    }
}
