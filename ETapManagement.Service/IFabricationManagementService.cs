using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service
{
    public interface IFabricationManagementService
    {
        public List<AsBuildStructure> GetAsBuildStructure(int projectId);
        public ResponseMessage AddStructurecomponent(ADDStructureComponentDetails input);

        public List<AsBuildStructureCost> GetAsBuildStructureCost(int projectId);
        public ResponseMessage AddStructureCost(ADDStructureCost input);
        public ResponseMessage UpdatetructureAttributes(SiteReqStructureVm input);
        public ResponseMessage AddComponentCost(ADDComponentCost input);

        public List<CostComponentDetailsDto> GetStructrueFabraiationComponent (int id);
         public ResponseMessage UpdateFabricationStatus(FabricationVm input);
          List<FabricationDetails> GetFabrication (SiteDeclarationDetailsPayload reqPayload);

           ResponseMessage FabricationApprove (FabricationApprovePayload reqPayload);

    }
}