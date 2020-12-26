using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;  

namespace ETapManagement.ViewModel.Dto
{
	public class AssignStructureComponentDetails
	{


		[Required]
		[Display(Name = "StructureId")]
		public int StructureId { get; set; }

		[Required]
		[Display(Name = "ProjectId")]
		public int ProjectId { get; set; }

		[Required]
		[StringLength(100)]
		[Display(Name = "DrawingNo")]
		public string DrawingNo { get; set; }


		[Required]
		public string StructureAttributes { get; set; }
	
		public IFormFile[] uploadDocs { get; set; }
        public string[] remove_docs_filename {get;set;} 
	}


	public class AssignStructureDtlsOnly
	{
		public int StructureId { get; set; }

		public int ProjectId { get; set; }
		public string DrawingNo { get; set; }
		public string StrcutureName { get; set; }
		public string StrcutureTypeName { get; set; }

		public string StructureCode { get; set; }
		public string ProjectName{get;set;}
		public string StructureAttributes { get; set; }
		public int? ComponentsCount { get; set; }		
		public List<ComponentDetails> Components { get; set; }
        public List<Upload_Docs> structureDocs {get;set;} 
	}

	public class ComponentQueryParam {
		[Required]
		public int StructId {get;set;}
		[Required]
		public int ProjectId{get;set;}
	}

	public class Upload_Docs {
    public int Id {get;set;} 
    public string fileName {get;set;}
    public string fileType {get;set;}
    public string uploadType {get;set;} 
    public string filepath {get;set;}    
}

	public class AddComponents
	{
		[Required]
		[Display(Name = "StructureId")]
		public int StructureId { get; set; }

		[Required]
		[Display(Name = "ProjectId")]
		public int ProjectId { get; set; }
		public List<ComponentDetails> Components { get; set; }
	}
}
