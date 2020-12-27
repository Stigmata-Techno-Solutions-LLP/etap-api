using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {
    public interface IAssignStructureComponentRepository {
        int UpsertProjectStructure (AssignStructureComponentDetails request);
        string StructureRemoveDocs (int docId);
        bool StructureDocsUpload (Upload_Docs request, int Id);
        AssignStructureDtlsOnly GetAssignStructureDtlsById (ComponentQueryParam filterReq);

        List<AssignStructureDtlsOnly> GetAssignStructureDtls ();
    }
}