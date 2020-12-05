using AutoMapper;
using ETapManagement.Domain;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETapManagement.Repository
{
    public class SegmentRepository : ISegmentRepository
    {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public SegmentRepository(ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo)
        {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

        public List<SegmentDetail> GetSegmentDetails()
        {
            try
            {
                List<SegmentDetail> result = new List<SegmentDetail>();
                var segments = _context.Segment.ToList();
                result = _mapper.Map<List<SegmentDetail>>(segments);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }             
        }
    }
}
