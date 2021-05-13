using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;
using ETapManagement.Common;
namespace ETapManagement.ViewModel.Dto {

     public class InitiateScrapStructure {
        [Required]
        public int DispStructId { get; set; }

        [Required]
        public int FromProjectId { get; set; }
        
        [Required]
        public int ProjStructId { get; set; }
        public int? RoleId{get;set;}
           public IFormFile[] uploadDocs { get; set; }
        public string[] remove_docs_filename { get; set; }

    }
    public class AddScrapStructure {
        [Required]
        public int SubconId { get; set; }

        [Required]
        public int ProjStructId { get; set; }

        [Required]
        [Display (Name = "Scarp Rate")]
        public decimal ScrapRate { get; set; }

        [Required]
        [Display (Name = "Auction Id")]
        [DataType (DataType.Text)]
        [StringLength (20)]
        public string AuctionId { get; set; }

        // [Required]
        // [Display (Name = "Status")]
        // [DataType (DataType.Text)]
        // [StringLength (50)]
        // public string Status { get; set; }
        public bool IsDelete { get; set; }
        public IFormFile[] uploadDocs { get; set; }
        public string[] remove_docs_filename { get; set; }

    }

    public class ScrapStructureDetail {
        public int Id { get; set; }
        public int SubconId { get; set; }
        public int ProjStructId { get; set; }
        public string StructName { get; set; }
        public string VendorName { get; set; }
        public decimal ScrapRate { get; set; }
        public string AuctionId { get; set; }
        public string Status { get; set; }
        public bool IsDelete { get; set; }

    }

    public class WorkFlowScrapPayload {
        [Required]
        public int? dispatch_structure_id { get; set; }

        [Required]
        public int scrap_id { get; set; }

        [Required]
        public commonEnum.WorkFlowMode mode { get; set; }

        public commonEnum.SurplusRolename role_name { get; set; }
        public string role_hierarchy { get; set; }

    }

   public class ScrapWorkflowDetailsPayload {
        public commonEnum.Rolename role_name { get; set; }
        public int? role_hierarchy { get; set; }

    }
       public class ScrapStructureWorkFlowDetail {
        public int isAction { get; set; }
        public int Id { get; set; }
        public int? FromProjectId { get; set; }
        public string FromProjectName {get;set;}
        public string ProjectCode {get;set;}
        public int ProjStructId { get; set; }
        public DateTime CreatedDate{get;set;}
        public int? DispStructId{get;set;}
        public string Status { get; set; }
        public string StructureName { get; set; }

    }
}