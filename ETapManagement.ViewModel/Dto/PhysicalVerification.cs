using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ETapManagement.Common;
using Microsoft.AspNetCore.Http;

namespace ETapManagement.ViewModel.Dto
{
    public class PhysicalVerificationDetail
    {
        public string StructureName { get; set; }
        public string StructureCode { get; set; }
        public string StructureFamily { get; set; }
        public int SiteId { get; set; }
        public int ProjectId { get; set; }
        public int ProjectstructureId { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int RoleId { get; set; }



    }
    public class SitePhysicalInpection
    {
        public DateTime? FromDueDate { get; set; }
        public DateTime? ToDueDate { get; set; }
        public string InspectionId { get; set; }
        public List<PhysicalVerificationDetail> StructList { get; set; }

    }
    public class InspectionPhysicalVerificationDetail
    {
        public string StructureName { get; set; }
        public string StructureCode { get; set; }
        public string StructureFamily { get; set; }
        public int SiteId { get; set; }
        public int ProjectId { get; set; }
        public int ProjectstructureId { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int RoleId { get; set; }
        public DateTime FromDueDate { get; set; }
        public DateTime ToDueDate { get; set; }

        public int siteVerfId { get; set; }
        public String InspectionId { get; set; }



    }

    public partial class InspecStrComponent
    {

        public int? SiteStructureVerfid { get; set; }
        public int ProjectStructureId { get; set; }
        public int DispStructureId { get; set; }
        public int? ComponentId { get; set; }
        public decimal? Leng { get; set; }
        public decimal? Breath { get; set; }
        public decimal? Height { get; set; }
        public decimal? Thickness { get; set; }
        public decimal? Weight { get; set; }
        public string QrCode { get; set; }
        public int? ProjStructId { get; set; }
        public string CompId { get; set; }
        public string Remarks{get;set;} 
         public string Status{get;set;} 
        public string ComponentName { get; set; }



    }
    public class PhysicalVerificationDocument
    {

        [Required]
        [Display(Name = "SiteCompPhysicalverfid")]
        public int sitestructurephysicalverfid { get; set; }
  
        public IFormFile[] uploadDocs { get; set; }
        public string[] remove_docs_filename { get; set; }
 

    }

     public class PhysicalVerificationstructure
    {
        public int StructurePhysicalverfId { get; set; }
        public string StructureName { get; set; }
        public string StructureCode { get; set; }
        public string ProjectName { get; set; }
        public string InspectionId { get; set; }
 



    }



}