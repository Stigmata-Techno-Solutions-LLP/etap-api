using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository { 

    public interface IFabricationManagementRepository
    {
       public List<AsBuildStructure> GetStructureLst(int projectId);
    }
}