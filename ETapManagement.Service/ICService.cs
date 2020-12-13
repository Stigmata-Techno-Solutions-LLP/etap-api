using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public class ICService : IICService {
        IICRepository _icRepository;

        public ICService(IICRepository icRepository) {
            _icRepository = icRepository;
        }  

        public ResponseMessage CreateIC(AddIndependentCompany independentCompany)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _icRepository.CreateIC(independentCompany);
            return responseMessage;
        }

        public ResponseMessage DeleteIC(int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _icRepository.DeleteIC(id);
            return responseMessage;
        }

        public List<Code> GetICCodeList()
        {
            List<Code> codes = _icRepository.GetICCodeList();
            return codes;
        } 

        public ResponseMessage UpdateIC(AddIndependentCompany independentCompany, int id)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            responseMessage = _icRepository.UpdateIC(independentCompany, id);
            return responseMessage;
        }

        public List<IndependentCompanyDetail> GetICDetails()
        {
            List<IndependentCompanyDetail> icDetails = _icRepository.GetICDetails();
            return icDetails;
        }

        public IndependentCompanyDetail GetICDetailsById(int id)
        {
            IndependentCompanyDetail icDetail = _icRepository.GetICDetailsById(id);
            return icDetail;
        }
    }
}