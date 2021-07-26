using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IScrapStructureService
    {
        public ResponseMessage UpdateScrapStructure(AddScrapStructure scrapStructure, int id);
        public List<ScrapStructureDetail> GetScrapStructureDetails();
        public ScrapStructureDetail GetScrapStructureDetailsById(int id);
        public ResponseMessage InitiateScrapStructure(InitiateScrapStructure scrapStructure);
         public List<ScrapStructureWorkFlowDetail> GetScrapWorkflowDetails (ScrapWorkflowDetailsPayload reqPayload);

    }
}