using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service
{
    public interface IAssignStructureComponentService
    {
        ResponseMessage UpsertAssignStructureComponent(AssignStructureComponentDetails servicedto);
        AssignStructureDtlsOnly GetAssignStructureDtlsById(ComponentQueryParam filterReq);
        AssignStructureDtlsOnly GetAssignStructureDtlsByProjStructId(int projStructId);
        List<AssignStructureDtlsOnly> GetAssignStructureDtls();
        List<Code> GetStructureCodeList(int ProjectId, int StrcutureId);
        List<ViewStructureChart> GetViewStructureChart (int projectStructureId);
    }
}