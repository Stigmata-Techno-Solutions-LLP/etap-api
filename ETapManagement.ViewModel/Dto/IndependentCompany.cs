using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETapManagement.ViewModel.Dto
{
	public class AddIndependentCompany
	{
		public int Id { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[StringLength(200)]
		[Display(Name = "Name")]
		public string Name { get; set; }

		[DataType(DataType.Text)]
		[StringLength(500)]
		[Display(Name = "Description")]
		public string Description { get; set; }
		public bool? IsDelete { get; set; }
	}
	public class IndependentCompanyDetail
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool? IsDelete { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
	}
}