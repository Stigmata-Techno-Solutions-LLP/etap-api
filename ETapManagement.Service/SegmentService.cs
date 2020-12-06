using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public class SegmentService : ISegmentService {
        ISegmentRepository _segementRepository;

        public SegmentService (ISegmentRepository segementRepository) {
            _segementRepository = segementRepository;
        }

        public List<SegmentDetail> GetSegmentDetails () {
            List<SegmentDetail> segmentDetails = _segementRepository.GetSegmentDetails ();
            return segmentDetails;
        }
    }
}