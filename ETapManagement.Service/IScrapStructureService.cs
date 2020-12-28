using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IScrapStructureService
    {
        public ResponseMessage CreateScrapStructure(AddScrapStructure scrapStructure);
        public ResponseMessage UpdateScrapStructure(AddScrapStructure scrapStructure, int id);
        public ResponseMessage DeleteScrapStructure(int id);
        public List<ScrapStructureDetail> GetScrapStructureDetails();
        public ScrapStructureDetail GetScrapStructureDetailsById(int id);
    }
}