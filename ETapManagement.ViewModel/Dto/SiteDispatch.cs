using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ETapManagement.Common;
using Microsoft.AspNetCore.Http;

namespace ETapManagement.ViewModel.Dto
{
    public class SiteDispatchDetail
    {
        public string MRNo { get; set; }

        public string DispatchNo { get; set; }

        public string Status { get; set; }

        public string StatusInternal { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int DispatchId { get; set; }

        public int SiteRequestId { get; set; }

        public string ServiceType { get; set; }

        public int ServiceTypeId { get; set; }
        public int SubContractorId { get; set; }
        public string SubContractorName { get; set; }
        public int DispatchRequestSubContractorId { get; set; }
        public decimal? FabricationCost { get; set; }
        public decimal? MonthlyRent {get;set;}
        public decimal? ContractYears {get;set;}
        public DateTime? PlanReleaseDate {get;set;}

    }

    public class StructureListCode
    {
        public int Id { get; set; }
        public string StructureId { get; set; }
        public string StructureName { get; set; }

    }

    public class SiteDispatchPayload
    {
        public commonEnum.Rolename role_name { get; set; }
        public int? role_hierarchy { get; set; }
    }

    public class DispatchVendorAddPayload
    {
        public int dispatchRequestSubContractorId { get; set; }
        public string workOrderNumber { get; set; }
        public DateTime dispatchDate { get; set; }
        public int updatedBy { get; set; }
        public int structureId { get; set; }
        public IFormFile[] uploadDocs { get; set; }

    }

    public class SiteDispatchUpload
    {
        public int Id { get; set; }
        public int DispatchSubContractorId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Path { get; set; }
    }

}