using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Repository;
using Microsoft.Extensions.Options;

namespace ETapManagement.Service
{
	public class SurplusService : ISurplusService
	{
		ISurplusRepository _surplusRepository;

		private readonly AppSettings _appSettings;

		public SurplusService(IOptions<AppSettings> appSettings, ISurplusRepository surplusRepository)
		{
			_surplusRepository = surplusRepository;
			_appSettings = appSettings.Value;
		}

		public List<SurplusDetails> GetSurplus()
		{
			List<SurplusDetails> surplus = _surplusRepository.GetSurplus();
			if (!(surplus?.Count > 0)) return null;

			return surplus;
		}

		public SurplusDetails GetSurplusById(int id)
		{
			SurplusDetails surplus = _surplusRepository.GetSurplusById(id);
			if (surplus == null) return null;

			return surplus;
		}

		public ResponseMessage AddSurplus(SurplusDetails surplus)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			responseMessage = _surplusRepository.AddSurplus(surplus);

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

		public ResponseMessage UpdateSurplus(SurplusDetails surplus, int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			responseMessage = _surplusRepository.UpdateSurplus(surplus, id);
			return responseMessage;
		}

		public ResponseMessage DeleteSurplus(int id)
		{
			ResponseMessage responseMessage = new ResponseMessage();
			responseMessage = _surplusRepository.DeleteSurplus(id);
			return responseMessage;
		}
	}
}