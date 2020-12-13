using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto
{
	public class StructureDetails
	{
		public int Id { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[StringLength(200)]
		[Display(Name = "Structure Name")]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Status")]
		public bool IsActive { get; set; }

		[Required]
		[Display(Name = "Structure Family")]
		public int StructureTypeId { get; set; }

		[Required]
		[Display(Name = "Structure Attributes")]
		public string StructureAttributes { get; set; }
	}
}
