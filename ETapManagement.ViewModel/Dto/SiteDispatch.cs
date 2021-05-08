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
        public string? MRNo { get; set; }

        public string? DispatchNo { get; set; }

        public string? Status { get; set; }

        public string? StatusInternal { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? DispatchId { get; set; }

        public int? SiteRequestId { get; set; }

        public string? ServiceType { get; set; }

        public int? ServiceTypeId { get; set; }
        public int? SubContractorId { get; set; }
        public string SubContractorName { get; set; }
        public int? DispatchRequestSubContractorId { get; set; }

        public string StructureName { get; set; }
        // public decimal? FabricationCost { get; set; }
        // public decimal? MonthlyRent {get;set;}
        // public decimal? ContractYears {get;set;}
        // public DateTime? PlanReleaseDate {get;set;}

    }

    public class StructureListCode
    {
        public int Id { get; set; }
        public string StructureId { get; set; }
        public string StructureName { get; set; }

    }

    public class DispatchStructureCodePayload
    {
        [Required]
        public int dispReqId { get; set; }

        [Required]
        public commonEnum.Rolename role_hierarchy { get; set; }
    }
    public class SiteDispatchPayload
    {
        public commonEnum.Rolename role_name { get; set; }
        public int? role_hierarchy { get; set; }
        public int? VendorId { get; set; }
        public int? ProjectId { get; set; }
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

    public class SiteDispatchScan
    {
        public int projectId { get; set; }
        public int structureId { get; set; }
        public int dispId { get; set; }

        public int fromProjId { get; set; }
        public List<SiteDispScanComp> lstScanComp { get; set; }

    }

    public class SiteDispScanComp
    {
        [Required]
        public int componentId { get; set; }

        [Required]
        public string qrCode { get; set; }
        public string remarks { get; set; }
    }

    public class SiteDispatchStructureDocs
    {

        public int dispReqId { get; set; }
        public int structureId { get; set; }
        public IFormFile[] uploadDocs { get; set; }
        public string[] remove_docs_filename { get; set; }
    }
    public class SiteDispatchScanUpload
    {
        public int Id { get; set; }
        public int DispatchSubContractorId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Path { get; set; }
    }

    public class DispatchTransferPrice
    {

        public int dispReqId { get; set; }
        public string roleName { get; set; }
        public decimal? transferPrice { get; set; }
    }

    public class SiteDispatchApproval
    {

        public int dispReqId { get; set; }
        public string roleName { get; set; }
        public int roleId { get; set; }
        public int serviceTypeId { get; set; }
        public int roleHierarchy { get; set; }
    }

    public class TWCCDispatch
    {
        public int SiteRequirementId { get; set; }
        public string MRNumber { get; set; }
        public string StructureName { get; set; }
        public int FromProjectId { get; set; }
        public string RequestBy { get; set; }
        public int StructureId { get; set; }
        public string RaisedBy { get; set; }
        public string RequestStatus { get; set; }
        public string StructureAttributes { get; set; }
        public int Quantity { get; set; }
    }

    public class TWCCDispatchInnerStructure
    {
        public int SiteRequirementId { get; set; }
        public int ProjectStructureId { get; set; }
        public int StructureId { get; set; }
        public string StructureCode { get; set; }
        public int ProjectId { get; set; }
        public string ProjectStructureAttributes { get; set; }
        public string SiteRequirementStructureAttributes { get; set; }
        public DateTime? PlanStartDate { get; set; }
        public DateTime? PlanReleaseDate { get; set; }
        public string ProjectCurrentStatus { get; set; }
        public string ProjectStructureStatus { get; set; }
        public DateTime? SurPlusFromDate { get; set; }
        public string ProjectName { get; set; }
        public DateTime? ExpReleaseDate { get; set; }
    }

    public class TWCCJsonValue
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class SiteRequirementDetailsForDispatch
    {
        public int SiteRequirementId { get; set; }
        public int StructureId { get; set; }
        public string StrutureAttributes { get; set; }
        public DateTime PlanStartDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public int Quantity { get; set; }
    }

    public class TWCCDispatchPayload
    {
        public int siteRequirementId { get; set; }
        public int ToProjectId { get; set; }
        public int ProjectStructureId { get; set; }
        public int StructureId { get; set; }
        public int ServiceTypeId { get; set; }
        public int Quantity { get; set; }
        public string TransferPrice { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int RoleId { get; set; }
        public int CreatedBy { get; set; }
        public bool IsDelete { get; set; }
        public string Notes { get; set; }
    }
    public class DispStructureCMPC
    {
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int RequiredComponenentCount { get; set; }
        public int CurrentComponentsCount { get; set; }
        public int ProjectStructureId { get; set; }
        public int DispatchRequirementId { get; set; }
        public int DispReqStructId { get; set; }

        public int Quantity { get; set; }
        public int projectId { get; set; }
        public int StructureId { get; set; }
        public string StructureCode { get; set; }
        public string ProjectName { get; set; }
        public string StructureAttValue { get; set; }
        public string StructrueName { get; set; }

    }
    public class DispReqStructureDto
    {

        public int? DispreqId { get; set; }
        public int? ProjStructId { get; set; }
        public bool IsModification { get; set; }
        public int DispatchRequirementId { get; set; }



    }

    public class DispRequestDto
    {
        public bool? isModified { get; set; }

        public int ProjectStructureId { get; set; }

        public int DispatchRequirementId { get; set; }

        public string DCNumber { get; set; }
        public int? Quantity { get; set; }

        public int projectId { get; set; }
        public int StructureId { get; set; }
        public string StructureCode { get; set; }
        public string ProjectName { get; set; }
        public string StructureAttValue { get; set; }
        public string StructrueName { get; set; }
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int DispStructureId { get; set; }


    }
    public class ComponentDetailsDto
    {
       // public int Id { get; set; }
        public int DispStructureId { get; set; }

        public string CompId { get; set; }
        public string ComponentName { get; set; }
        public string ComponentType { get; set; }

        public string DrawingNo { get; set; }

        public int DispstructCompId { get; set; }

        public bool? IsGroup { get; set; }
        public decimal? Leng { get; set; }
        public decimal? Breath { get; set; }
        public decimal? Height { get; set; }
        public decimal? Thickness { get; set; }
        public decimal? Weight { get; set; }

        public string MakeType { get; set; }
        public decimal? ModStageLength { get; set; }
        public decimal? ModStageWeight { get; set; }
        public decimal? ModStageThikness { get; set; }
          public decimal? ModStageHeight { get; set; }
        public decimal? ModStagebreath { get; set; }
       public int? ModStageCompId { get; set; }


        public bool? IsTag { get; set; }
    }

     public class ComponentDetailsInput
    {
       // public int Id { get; set; }
        public int DispStructureId { get; set; }

        public string CompId { get; set; }
        public string ComponentName { get; set; }
        public string ComponentType { get; set; }

        public string DrawingNo { get; set; }

        public int DispstructCompId { get; set; }
          public int DispCompId {get;set;}
 
    }
    public partial class DispModStageComponentDto
    {
        public int Id { get; set; }
        public int? DispstructCompId { get; set; }

         public string DCNumber { get; set; }

        public int DispatchRequirementId { get; set; }
        public int ProjectStructureId { get; set; }
        public int DispStructureId { get; set; }
        public int? ComponentId { get; set; }
        public decimal? Leng { get; set; }
        public decimal? Breath { get; set; }
        public decimal? Height { get; set; }
        public decimal? Thickness { get; set; }
        public decimal? Weight { get; set; }
        public string MakeType { get; set; }
        public string Addplate { get; set; }
        public string QrCode { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }


    }
    public partial class DispComponentDto
    {
       // public int Id { get; set; }
        public int? DispstructCompId { get; set; }

        public int DispatchRequirementId { get; set; }
        public int ProjectStructureId { get; set; }
        public int DispStructureId { get; set; }
        public int? ComponentId { get; set; }

        public bool IsSite { get; set; }
        public bool IsVendor { get; set; }
      
        public OSDispatchReqSubCont OSDispatchReqSubCont { get; set; }


    }


    public class CMPCUpdateStructure
    {

        [Required]
        [Display(Name = "ProjStructureId")]
        public int ProjStructureId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "DrawingNo")]
        public string DrawingNo { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Estimated Weight")]
        public string EstimatedWeight { get; set; }



        [Required]
        [Display(Name = "CompCount")]
        public int CompCount { get; set; }

        public IFormFile[] uploadDocs { get; set; }
        public string[] remove_docs_filename { get; set; }

        [Required]
        public int dispStructureId { get; set; }
        public string StructureAttValue { get; set; }
        public string StructrueName { get; set; }

    }

    public class SubContractorDetail
    {
        public int DispSubContractorId { get; set; }
        public string DCNumber { get; set; }
        public string StructureCode { get; set; }
        public string StructureName { get; set; }
        public int Quantity { get; set; }
        public string StructureAttributesValue { get; set; }
        public int DispStructureId { get; set; }
        public int ComponentCount { get; set; }
    }

    public class SubContractorComponentDetail
    {
        public int DispStructureComponentId { get; set; }
        public string ComponentName { get; set; }
        public string ComponentType { get; set; }
        public string ComponentId { get; set; }
        public string DrawingNumber { get; set; }
    }

    public class SubContractorComponentPayload
    {
        public int DispSubContractorId { get; set; }
        public string DispatchReqSubContractorIds { get; set; }
        public DateTime DispatchDate { get; set; }
        public IFormFile[] uploadDocs { get; set; }
    }
}