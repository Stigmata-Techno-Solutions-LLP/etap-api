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
		[RegularExpression("[^0-9]", ErrorMessage = "StructureId must be numeric")]
		public int? StructureId { get; set; }

		[Required]
		[Display(Name = "ProjectId")]
		[RegularExpression("[^0-9]", ErrorMessage = "ProjectId must be numeric")]
		public int? ProjectId { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[StringLength(100)]
		[Display(Name = "DrawingNo")]
		public string DrawingNo { get; set; }

		[Required]
		[Display(Name = "Components Count")]
		[RegularExpression("[^0-9]", ErrorMessage = "Components Count must be numeric")]
		public int? ComponentsCount { get; set; }


		public bool? IsDelete { get; set; }
	}
}
