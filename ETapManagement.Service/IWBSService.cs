using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IWBSService {
        public ResponseMessage BulkInsertWBS (List<AddWorkBreakDown> lstWBS);
        public List<WorkBreakDownDetails> GetWBSDetailsList ();
        public WorkBreakDownDetails GetWBSDetailsById (int Id);
        public List<WorkBreakDownCode> GetWBSCodeList ();
        public List<WorkBreakDownCode> GetProjectWBSCodeList(int projectId);
        public ResponseMessage DeleteWBS (int Id);
    }
}