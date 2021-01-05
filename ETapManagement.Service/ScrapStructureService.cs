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

        public ResponseMessage CreateScrapStructure(AddScrapStructure scrapStructure)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _scrapStructureRepository.CreateScrapStructure (scrapStructure);
            return responseMessage;
        }

        public ResponseMessage UpdateScrapStructure(AddScrapStructure scrapStructure, int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _scrapStructureRepository.UpdateScrapStructure(scrapStructure, id);
            return responseMessage;
        }

        public ResponseMessage DeleteScrapStructure(int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _scrapStructureRepository.DeleteScrapStructure(id);
            return responseMessage;
        }

        public List<ScrapStructureDetail> GetScrapStructureDetails()
        {
            List<ScrapStructureDetail> scrapStructureDetails = _scrapStructureRepository.GetScrapStructureDetails();
            return scrapStructureDetails;
        }

        public ScrapStructureDetail GetScrapStructureDetailsById(int id)
        {
            ScrapStructureDetail scrapStructureDetail = _scrapStructureRepository.GetScrapStructureDetailsById(id);
            return scrapStructureDetail;
        }
    }
}