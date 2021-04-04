using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IAssignStructureComponentService {
        ResponseMessage UpsertAssignStructureComponent (AssignStructureComponentDetails servicedto);
        AssignStructureDtlsOnly GetAssignStructureDtlsById (ComponentQueryParam filterReq);
             AssignStructureDtlsOnly GetAssignStructureDtlsByProjStructId (int projStructId);

        List<AssignStructureDtlsOnly> GetAssignStructureDtls ();

    }
}