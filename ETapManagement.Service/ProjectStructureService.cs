using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

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
			List<ProjectStructureDetails> response = _repository.GetProjectStructure();
			if (!(response?.Count > 0)) return null;

			return response;
		}

		public ProjectStructureDetails GetProjectStructureById(int id)
		{
			ProjectStructureDetails response = _repository.GetProjectStructureById(id);
			if (response == null) return null;

			return response;
		}

		public ResponseMessage AddProjectStructure(ProjectStructureDetails servicedto)
		{
			ResponseMessage response = new ResponseMessage();
			response = _repository.AddProjectStructure(servicedto);

			if (response != null)
				return response;
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
			ResponseMessage response = new ResponseMessage();
			response = _repository.UpdateProjectStructure(servicedto, id);
			return response;
		}

		public ResponseMessage DeleteProjectStructure(int id)
		{
			ResponseMessage response = new ResponseMessage();
			response = _repository.DeleteProjectStructure(id);
			return response;
		}
	}
}
