using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IAssignStructureComponentService {
        ResponseMessage UpsertAssignStructureComponent (AssignStructureComponentDetails servicedto);
        AssignStructureDtlsOnly GetAssignStructureDtlsById (ComponentQueryParam filterReq);
        List<AssignStructureDtlsOnly> GetAssignStructureDtls ();

    }
}