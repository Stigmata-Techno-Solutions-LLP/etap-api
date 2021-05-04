using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository { 

    public interface IPhysicalVerificationRepository
    {
        public List<PhysicalVerificationDetail> GetPhysicalVerificationStructure (int projectId);
         public List<InspectionPhysicalVerificationDetail> GetSitePhysicalVerificationStructure(int projectId);
    }
}