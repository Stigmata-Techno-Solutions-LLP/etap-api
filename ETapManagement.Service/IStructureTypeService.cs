using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IStructureTypeService {
        public ResponseMessage CreateStructureType (AddStructureType structureType);
        public ResponseMessage UpdateStructureType (AddStructureType structureType, int id);
        public ResponseMessage DeleteStructureType (int id);
        public List<StructureTypeDetail> GetStructureTypeDetails ();
        public StructureTypeDetail GetStructureTypeDetailsById (int id);
        public List<Code> GetStructureTypeCodeList ();
    }
}