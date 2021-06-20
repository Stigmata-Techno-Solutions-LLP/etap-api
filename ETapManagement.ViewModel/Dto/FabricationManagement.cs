using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ETapManagement.Common;
using Microsoft.AspNetCore.Http;

namespace ETapManagement.ViewModel.Dto
{

    public class AsBuildStructure
    {
        public string Status { get; set; }
        public string StatusInternal { get; set; }
        public int RequiredComponenentCount { get; set; }

        public int ProjectStructureId { get; set; }
        public int DispatchRequirementId { get; set; }
        public int DispReqStructId { get; set; }
        public string DispatchNo { get; set; }

        public int Quantity { get; set; }
        public int projectId { get; set; }
        public int StructureId { get; set; }
        public string StructureCode { get; set; }
        public string ProjectName { get; set; }

        public string StructrueName { get; set; }


    }
    public class ADDStructureComponentDetails
    {

        public int StructureId { get; set; }

        public int DispatchRequirementId { get; set; }
        public string StructureCode { get; set; }

        public int ProjectId { get; set; }
        public int ProjectStructureId { get; set; }

        public string DrawingNo { get; set; }

        public string EstimatedWeight { get; set; }

        public string StructureAttributes { get; set; }

        public int CompCount { get; set; }

        public IFormFile[] uploadDocs { get; set; }
        public string[] remove_docs_filename { get; set; }
        public int? ActualWbs { get; set; }
        public DateTime? FabricationYear { get; set; }
        public string Remarks { get; set; }
        public decimal? ActualWeight { get; set; }
        public bool? Reusuability { get; set; }



    }

    public class ADDStructureCost
    {

        public int StructureId { get; set; }
        public int DispatchRequirementId { get; set; }
        public string StructureCode { get; set; }
        public int ProjectId { get; set; }
        public int ProjectStructureId { get; set; }
        public IFormFile[] uploadDocs { get; set; }
        public string[] remove_docs_filename { get; set; }

        public decimal Cost { get; set; }




    }

    public class SiteReqStructureVm
    {

        public int SiteReqStructureId { get; set; }
        public string StructureAttributesVal { get; set; }

    }

    public class ADDComponentCost
    {
        public int DispStructureCompId { get; set; }
        public decimal Cost { get; set; }

    }

    public class CostComponentDetailsDto
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

        public decimal? Cost { get; set; }
        public bool? IsTag { get; set; }
    }


    public class FabricationVm
    {

        public int projectstructreId { get; set; }
        public int DisptachRequiremntstructureId { get; set; }
        public int DispatchRequiremntId { get; set; }


    }



}