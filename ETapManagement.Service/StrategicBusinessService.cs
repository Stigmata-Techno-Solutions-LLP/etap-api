using System.Collections.Generic;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service
{
	public class StrategicBusinessService : IStrategicBusinessService
	{
		IStrategicBusinessRepository _sbgRepository;
		public StrategicBusinessService(IStrategicBusinessRepository sbgRepository)
		{
			_sbgRepository = sbgRepository;
		}
		public ResponseMessage CreateStrategicBusiness(AddStrategicBusiness strategicBusiness)
		{
			ResponseMessage response = new ResponseMessage();
			response = _sbgRepository.CreateStrategicBusiness(strategicBusiness);
			return response;
		}

		public ResponseMessage DeleteStrategicBusiness(int id)
		{
			ResponseMessage response = _sbgRepository.DeleteStrategicBusiness(id);
			return response;
		}

		public StrategicBusinessDetails GetStrategicBusinessById(int id)
		{
			StrategicBusinessDetails singleSbg = _sbgRepository.GetStrategicBusinessById(id);
			if (singleSbg == null) return null;
			return singleSbg;
		}

		public List<StrategicBusinessCodeList> GetStrategicBusinessCodeList()
		{
			List<StrategicBusinessCodeList> sbgCodeList = _sbgRepository.GetStrategicBusinessCodeList();
			return sbgCodeList;
		}

		public List<StrategicBusinessDetails> GetStrategicBusinessList()
		{
			List<StrategicBusinessDetails> sbgList = new List<StrategicBusinessDetails>();
			sbgList = _sbgRepository.GetStrategicBusinessList();
			return sbgList;
		}

		public ResponseMessage UpdateStrategicBusiness(AddStrategicBusiness strategicBusiness, int id)
		{
			ResponseMessage response = _sbgRepository.UpdateStrategicBusiness(strategicBusiness, id);
			return response;
		}
	}
}