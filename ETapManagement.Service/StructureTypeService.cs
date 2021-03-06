using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Repository;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public class StructureTypeService : IStructureTypeService {
        IStructureTypeRepository _structureTypeRepository;

        public StructureTypeService (IStructureTypeRepository structureTypeRepository) {
            _structureTypeRepository = structureTypeRepository;
        }

        public ResponseMessage CreateStructureType (AddStructureType structureType) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _structureTypeRepository.CreateStructureType (structureType);
            return responseMessage;
        }

        public ResponseMessage DeleteStructureType (int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _structureTypeRepository.DeleteStructureType (id);
            return responseMessage;
        }

        public List<Code> GetStructureTypeCodeList () {
            List<Code> codes = _structureTypeRepository.GetStructureTypeCodeList ();
            return codes;
        }

        public List<StructureTypeDetail> GetStructureTypeDetails () {
            List<StructureTypeDetail> structureTypeDetails = _structureTypeRepository.GetStructureTypeDetails ();
            return structureTypeDetails;
        }

        public StructureTypeDetail GetStructureTypeDetailsById (int id) {
            StructureTypeDetail structureTypeDetail = _structureTypeRepository.GetStructureTypeDetailsById (id);
            return structureTypeDetail;
        }

        public ResponseMessage UpdateStructureType (AddStructureType structureType, int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _structureTypeRepository.UpdateStructureType (structureType, id);
            return responseMessage;
        }
    }
}