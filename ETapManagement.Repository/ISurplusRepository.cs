using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {
    public interface ISurplusRepository {
        List<SurplusDetails> GetSurplus (SiteDeclarationDetailsPayload reqPayload);
        SurplusDetails GetSurplusById (int id);
        int AddSurplus (AddSurplus surplus);
        ResponseMessage UpdateSurplus (SurplusDetails surplus, int id);
        ResponseMessage DeleteSurplus (int id);
        ResponseMessage WorkflowSurplusDecl (WorkFlowSurplusDeclPayload reqPayload);

        bool SurplusRemoveDocs (string request);
        bool SiteDeclDocsUpload (Upload_Docs request, int Id);
    }
}