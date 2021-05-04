using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IPhysicalVerificationService
    {
        public List<PhysicalVerificationDetail> GetPhysicalVerificationStructure (int projectId);
         public List<InspectionPhysicalVerificationDetail> GetSitePhysicalVerificationStructure(int projectId);
         public ResponseMessage SiteStructurePhysicalverify(SitePhysicalInpection Structure);
            public ResponseMessage AddSitePhysicalverifyComponent(List<InspecStrComponent> component);
          public List<InspecStrComponent> GetInspectionComponent(int ProjStructId);
       
    }
}