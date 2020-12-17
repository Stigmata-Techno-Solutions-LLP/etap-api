using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {
    public interface IStructureTypeRepository
    {
        public ResponseMessage CreateStructureType (StructureTypeDetail structureTypeDetail);
        public ResponseMessage UpdateStructureType(StructureTypeDetail structureTypeDetail, int id);
        public ResponseMessage DeleteStructureType(int id);
        public List<StructureTypeDetail> GetStructureTypeDetails();
        public StructureTypeDetail GetStructureTypeDetailsById(int id);
        public List<Code> GetStructureTypeCodeList();
    }
}