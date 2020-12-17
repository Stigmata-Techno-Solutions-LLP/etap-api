using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.Service
{
	public class AssignStructureComponentService : IAssignStructureComponentService
	{
		IAssignStructureComponentRepository _repository;

		private readonly AppSettings _appSettings;

		public AssignStructureComponentService(IOptions<AppSettings> appSettings, IAssignStructureComponentRepository repository)
		{
			_repository = repository;
			_appSettings = appSettings.Value;
		}

		public ResponseMessage UpsertAssignStructureComponent(AssignStructureComponentDetails servicedto)
		{
			ResponseMessage response = new ResponseMessage();
			response = _repository.UpsertProjectStructure(servicedto);

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
	}
}
