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

    public class SiteDispatchDetailPayload
    {
        public int DispatchRequestSubContractorId { get; set; }
        public string WorkOrderNumber { get; set; }
        public DateTime DispatchDate { get; set; }
        public int UpdatedBy { get; set; }
        public int StructureId { get; set; }
        public IFormFile[] UploadDocs { get; set; }

    }

    public class SiteDispatchUpload
    {
        public int Id {get;set;}
        public int DispatchSubContractorId {get;set;}
        public string FileName {get;set;}
        public string FileType {get;set;}
        public string Path {get;set;}
    }

}