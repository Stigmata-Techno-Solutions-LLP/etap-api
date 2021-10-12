using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository { 

    public interface IFabricationManagementRepository
    {
       public List<AsBuildStructure> GetStructureLst(int projectId);
     public List<AsBuildStructureCost> GetAsBuildStructureCost(int projectId);
      public List<CostComponentDetailsDto> GetStructrueFabraiationComponent (int id);

      	   List<FabricationDetails> GetFabrication (SiteDeclarationDetailsPayload reqPayload);
           ResponseMessage FabricationApprove (FabricationApprovePayload reqPayload);
    }
}