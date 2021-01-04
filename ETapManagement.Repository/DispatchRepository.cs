using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore;

namespace ETapManagement.Repository {

    public class DispatchRepository : IDispatchRepository {
        private readonly ETapManagementContext _context;
        private readonly IMapper _mapper;
        private readonly ICommonRepository _commonRepo;

        public DispatchRepository (ETapManagementContext context, IMapper mapper, ICommonRepository commonRepo) {
            _context = context;
            _mapper = mapper;
            _commonRepo = commonRepo;
        }

                public ResponseMessage CreateDispatch (AddDispatch dispatchReq) {
 foreach(DispatchStructure dispStr in dispatchReq.dispStructureDtls) {
 }
                    ResponseMessage resp = new ResponseMessage();
                    return resp;
                }       


        
    }
}