using System;
using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface ISurplusService {
        List<SurplusDetails> GetSurplus (SiteDeclarationDetailsPayload reqPayload);
        SurplusDetails GetSurplusById (int id);
        ResponseMessage AddSurplus (AddSurplus surplusDetails);
        ResponseMessage WorkflowSurplusDecl (WorkFlowSurplusDeclPayload reqPayload);

    }
}