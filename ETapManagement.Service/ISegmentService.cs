using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.Service
{
    public interface ISegmentService
    {
        public List<SegmentDetail> GetSegmentDetails();
    }
}
