using System;
using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service
{
	public interface ISurplusService
	{
		List<SurplusDetails> GetSurplus(SiteDeclarationDetailsPayload reqPayload);
		SurplusDetails GetSurplusById(int id);
		ResponseMessage AddSurplus(AddSurplus surplusDetails);
		ResponseMessage UpdateSurplus(SurplusDetails surplusDetails, int id);
		ResponseMessage DeleteSurplus(int id);
		ResponseMessage WorkflowSurplusDecl (WorkFlowSurplusDeclPayload reqPayload);

	}
}