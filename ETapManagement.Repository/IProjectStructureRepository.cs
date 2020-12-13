using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

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