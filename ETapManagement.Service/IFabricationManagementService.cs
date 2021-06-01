using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IFabricationManagementService
    {
           public List<AsBuildStructure> GetAsBuildStructure (int projectId);
           public ResponseMessage AddStructurecomponent(ADDStructureComponentDetails input);
       
    }
}