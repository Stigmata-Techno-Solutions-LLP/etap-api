using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service
{
	public interface IStrategicBusinessService
	{
		public ResponseMessage CreateStrategicBusiness(AddStrategicBusiness strategicBusiness);
		public List<StrategicBusinessDetails> GetStrategicBusinessList();
		public StrategicBusinessDetails GetStrategicBusinessById(int id);
		public List<StrategicBusinessCodeList> GetStrategicBusinessCodeList();
		public ResponseMessage UpdateStrategicBusiness(AddStrategicBusiness strategicBusiness, int id);
		public ResponseMessage DeleteStrategicBusiness(int id);

	}
}