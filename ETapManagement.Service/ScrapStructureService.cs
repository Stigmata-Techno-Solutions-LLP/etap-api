using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public class ScrapStructureService : IScrapStructureService
    {
        IScrapStructureRepository _scrapStructureRepository;

        public ScrapStructureService(IScrapStructureRepository scrapStructureRepository) {
            _scrapStructureRepository = scrapStructureRepository;
        } 

         public ResponseMessage InitiateScrapStructure(InitiateScrapStructure scrapStructure)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _scrapStructureRepository.InitiateScrapStructure (scrapStructure);
            return responseMessage;
        }

        public ResponseMessage UpdateScrapStructure(AddScrapStructure scrapStructure, int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _scrapStructureRepository.UpdateScrapStructure(scrapStructure, id);
            return responseMessage;
        }


        public List<ScrapStructureDetail> GetScrapStructureDetails()
        {
            List<ScrapStructureDetail> scrapStructureDetails = _scrapStructureRepository.GetScrapStructureDetails();
            return scrapStructureDetails;
        }
          public List<ScrapStructureWorkFlowDetail> GetScrapWorkflowDetails(ScrapWorkflowDetailsPayload payload)
        {
            List<ScrapStructureWorkFlowDetail> scrapStructureDetails = _scrapStructureRepository.GetScrapWorkflowDetails(payload);
            return scrapStructureDetails;
        }

        public ScrapStructureDetail GetScrapStructureDetailsById(int id)
        {
            ScrapStructureDetail scrapStructureDetail = _scrapStructureRepository.GetScrapStructureDetailsById(id);
            return scrapStructureDetail;
        }
    }
}