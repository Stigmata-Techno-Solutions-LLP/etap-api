using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IBUService {
        public ResponseMessage CreateBU(AddBusinessUnit businessunit);
        public ResponseMessage UpdateBU(AddBusinessUnit businessunit, int id);
        public ResponseMessage DeleteBU(int id);
        public List<BusinessUnitDetail> GetBUDetails();
        public BusinessUnitDetail GetBUDetailsById(int id);
        public List<Code> GetBUCodeList();


    }
}