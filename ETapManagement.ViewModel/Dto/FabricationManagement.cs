using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ETapManagement.Common;
using Microsoft.AspNetCore.Http;

namespace ETapManagement.ViewModel.Dto
{

    public class AsBuildStructure
    {  public string Status { get; set; }
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

        public string StructrueName{get;set;}
        

    }
    public class ADDStructureComponentDetails
    {

        public int StructureId { get; set; }

          public int DispatchRequirementId { get; set; }
        public string StructureCode { get; set; }

        public int ProjectId { get; set; }
        public int  ProjectStructureId { get; set; }

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
        public int  ProjectStructureId { get; set; }
        public IFormFile[] uploadDocs { get; set; }
        public string[] remove_docs_filename { get; set; }

        public decimal Cost {get; set;}
       
 


    }








}