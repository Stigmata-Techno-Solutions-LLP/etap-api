using System;
using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IStructureService {
        List<StructureDetails> GetStructures ();
        StructureDetails GetStructureById (int id);
        ResponseMessage AddStructure (StructureDetails structureDetails);
        ResponseMessage UpdateStructure (StructureDetails structureDetails, int id);
        ResponseMessage DeleteStructure (int id);
        List<Code> GetProjectCodeList ();

    }
}