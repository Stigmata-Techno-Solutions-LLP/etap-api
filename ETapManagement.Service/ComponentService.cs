using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.Service
{
	public class ComponentService : IComponentService
	{
		IComponentRepository _repository;

		private readonly AppSettings _appSettings;

		public ComponentService(IOptions<AppSettings> appSettings, IComponentRepository repository)
		{
			_repository = repository;
			_appSettings = appSettings.Value;
		}

		public List<ComponentDetails> GetComponent()
		{
			List<ComponentDetails> response = _repository.GetComponent();
			if (!(response?.Count > 0)) return null;

			return response;
		}

		public ComponentDetails GetComponentById(int id)
		{
			ComponentDetails response = _repository.GetComponentById(id);
			if (response == null) return null;

			return response;
		}

		public List<ComponentDetails> GetComponentHistoryByCode(string compCode)
		{
			List<ComponentDetails> response = _repository.GetComponentHistoryByCode(compCode);
			if (!(response?.Count > 0)) return null;

			return response;
		}
		public ResponseMessage AddComponent(ComponentDetails servicedto)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			responseMessage = _repository.AddComponent(servicedto);

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

		public ResponseMessage UpdateComponent(ComponentDetails servicedto, int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			responseMessage = _repository.UpdateComponent(servicedto, id);
			return responseMessage;
		}

		public ResponseMessage DeleteComponent(int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			responseMessage = _repository.DeleteComponent(id);
			return responseMessage;
		}
	}
}
