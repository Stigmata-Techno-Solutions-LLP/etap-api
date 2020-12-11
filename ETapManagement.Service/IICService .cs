using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IICService {
        public ResponseMessage CreateIC(IndependentCompanyDetail icDetail);
        public ResponseMessage UpdateIC(IndependentCompanyDetail icDetail, int id);
        public ResponseMessage DeleteIC(int id);
        public List<IndependentCompanyDetail> GetICDetails();
        public IndependentCompanyDetail GetICDetailsById(int id);
        public List<Code> GetICCodeList();


    }
}