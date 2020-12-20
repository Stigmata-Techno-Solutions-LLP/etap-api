using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto
{
	public class ProjectStructureDetails
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "StructureId")]
		public int? StructureId { get; set; }

		[Required]
		[Display(Name = "ProjectId")]
		public int? ProjectId { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[StringLength(100)]
		[Display(Name = "DrawingNo")]
		public string DrawingNo { get; set; }

		[Required]
		[Display(Name = "Components Count")]
		public int? ComponentsCount { get; set; }
		public bool? IsDelete { get; set; }
	}
}
