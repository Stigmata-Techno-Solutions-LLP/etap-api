using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;  

namespace ETapManagement.ViewModel.Dto
{
	public class AssignStructureComponentDetails
	{

	//	public int Id { get; set; }

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
		[Display(Name = "Components Count")]
		public int? ComponentsCount { get; set; }
		public string strComponents{get;set;}
		public List<ComponentDetails> Components { get; set; }
		public IFormFile[] uploadDocs { get; set; }
        public string[] remove_docs_filename {get;set;} 
	}

	public class Upload_Docs {
    
    public int Id {get;set;} 
    public string fileName {get;set;}
    public string fileType {get;set;}
    public string uploadType {get;set;} 
    public string filepath {get;set;}    
}
}
