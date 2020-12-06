using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface ISegmentService {
        public List<SegmentDetail> GetSegmentDetails ();
    }
}