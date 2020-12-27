using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {
    public interface IWBSRepository {
        public ResponseMessage BulkInsertWBS (List<AddWorkBreakDown> lstWBS);
        public List<WorkBreakDownDetails> GetWBSDetailsList ();
        public WorkBreakDownDetails GetWBSDetailsById (int Id);
        public List<WorkBreakDownCode> GetWBSCodeList ();
        public ResponseMessage DeleteWBS (int Id);

    }
}