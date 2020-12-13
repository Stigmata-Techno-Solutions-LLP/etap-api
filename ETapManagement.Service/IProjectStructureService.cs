using System;
using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service
{
	public interface IProjectStructureService
	{
		List<ProjectStructureDetails> GetProjectStructure();
		ProjectStructureDetails GetProjectStructureById(int id);
		ResponseMessage AddProjectStructure(ProjectStructureDetails structureDetails);
		ResponseMessage UpdateProjectStructure(ProjectStructureDetails structureDetails, int id);
		ResponseMessage DeleteProjectStructure(int id);
	}
}