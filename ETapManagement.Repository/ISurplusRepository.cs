using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository
{
	public interface ISurplusRepository
	{
		List<SurplusDetails> GetSurplus();
		SurplusDetails GetSurplusById(int id);
		ResponseMessage AddSurplus(SurplusDetails surplus);
		ResponseMessage UpdateSurplus(SurplusDetails surplus, int id);
		ResponseMessage DeleteSurplus(int id);
	}
}