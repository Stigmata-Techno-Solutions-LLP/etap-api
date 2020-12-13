using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Repository;
using Microsoft.Extensions.Options;

namespace ETapManagement.Service
{
	public class ProjectStructureService : IProjectStructureService
	{
		IProjectStructureRepository _repository;

		private readonly AppSettings _appSettings;

		public ProjectStructureService(IOptions<AppSettings> appSettings, IProjectStructureRepository repository)
		{
			_repository = repository;
			_appSettings = appSettings.Value;
		}

		public List<ProjectStructureDetails> GetProjectStructure()
		{
			List<ProjectStructureDetails> structures = _repository.GetProjectStructure();
			if (!(structures?.Count > 0)) return null;

			return structures;
		}

		public ProjectStructureDetails GetProjectStructureById(int id)
		{
			ProjectStructureDetails dto = _repository.GetProjectStructureById(id);
			if (dto == null) return null;

			return dto;
		}

		public ResponseMessage AddProjectStructure(ProjectStructureDetails servicedto)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			responseMessage = _repository.AddProjectStructure(servicedto);

			if (responseMessage != null)
				return responseMessage;
			else
			{
				return new ResponseMessage()
				{
					Message = "",
				};
			}
		}

		public ResponseMessage UpdateProjectStructure(ProjectStructureDetails servicedto, int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			responseMessage = _repository.UpdateProjectStructure(servicedto, id);
			return responseMessage;
		}

		public ResponseMessage DeleteProjectStructure(int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			responseMessage = _repository.DeleteProjectStructure(id);
			return responseMessage;
		}
	}
}