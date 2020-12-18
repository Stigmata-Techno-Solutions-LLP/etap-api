using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto
{
	public class SurplusDetails
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Structure Family")]
		public int StructureTypeId { get; set; }

		[Required]
		[Display(Name = "Project Id")]
		public int ProjectId { get; set; }

		[Required]
		[Display(Name = "Structure Id")]
		public int StructureId { get; set; }

		[DataType(DataType.Text)]
		[StringLength(500)]
		[Display(Name = "Existing Site")]
		public string Site { get; set; }

		public DateTime SurplusFrom { get; set; }

		[DataType(DataType.Text)]
		[StringLength(500)]
		[Display(Name = "Photo")]
		public string Photo { get; set; }

		public bool IsDelete { get; set; }
		public int? CreatedBy { get; set; }
		public DateTime? CreatedAt { get; set; }
		public int? UpdatedBy { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
