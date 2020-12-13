using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.Repository
{
	public interface IProjectStructureRepository
	{
		List<ProjectStructureDetails> GetProjectStructure();
		ProjectStructureDetails GetProjectStructureById(int id);
		ResponseMessage AddProjectStructure(ProjectStructureDetails projectStructure);
		ResponseMessage UpdateProjectStructure(ProjectStructureDetails projectStructure, int id);
		ResponseMessage DeleteProjectStructure(int id);
	}
}
