using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.Service
{
    public class SegmentService : ISegmentService
    {
        ISegmentRepository _segementRepository;

        public SegmentService(ISegmentRepository segementRepository)
        {
            _segementRepository = segementRepository;
        }

        public List<SegmentDetail> GetSegmentDetails()
        {
            throw new NotImplementedException();
        }
    }
}
