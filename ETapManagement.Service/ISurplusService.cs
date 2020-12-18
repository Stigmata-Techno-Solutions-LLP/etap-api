using System;
using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service
{
	public interface ISurplusService
	{
		List<SurplusDetails> GetSurplus();
		SurplusDetails GetSurplusById(int id);
		ResponseMessage AddSurplus(SurplusDetails surplusDetails);
		ResponseMessage UpdateSurplus(SurplusDetails surplusDetails, int id);
		ResponseMessage DeleteSurplus(int id);
	}
}