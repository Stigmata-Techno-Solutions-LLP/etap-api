using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {
    public interface ISurplusRepository {
        List<SurplusDetails> GetSurplus (SiteDeclarationDetailsPayload reqPayload);
        SurplusDetails GetSurplusById (int id);
        int AddSurplus (AddSurplus surplus);
        ResponseMessage WorkflowSurplusDecl (WorkFlowSurplusDeclPayload reqPayload);

        bool SurplusRemoveDocs (string request);
        bool SiteDeclDocsUpload (Upload_Docs request, int Id);
    }
}