using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public class WBSService : IWBSService {
        IWBSRepository _wbsRepository;

        public WBSService (IWBSRepository wbsRepository) {
            _wbsRepository = wbsRepository;
        }

        public ResponseMessage BulkInsertWBS (List<AddWorkBreakDown> lstWBS) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _wbsRepository.BulkInsertWBS (lstWBS);
            return responseMessage;
        }

        public WorkBreakDownDetails GetWBSDetailsById (int Id) {
            return _wbsRepository.GetWBSDetailsById (Id);
        }

        public List<WorkBreakDownDetails> GetWBSDetailsList () {
            List<WorkBreakDownDetails> wbsDtls = _wbsRepository.GetWBSDetailsList ();
            return wbsDtls;
        }

        public List<WorkBreakDownCode> GetWBSCodeList () {
            List<WorkBreakDownCode> wbsDtls = _wbsRepository.GetWBSCodeList ();
            return wbsDtls;
        }
        
        public List<WorkBreakDownCode> GetProjectWBSCodeList (int projectId) {
            List<WorkBreakDownCode> wbsDtls = _wbsRepository.GetProjectWBSCodeList (projectId);
            return wbsDtls;
        }
      

        public ResponseMessage DeleteWBS (int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _wbsRepository.DeleteWBS (id);
            return responseMessage;
        }
    }
}