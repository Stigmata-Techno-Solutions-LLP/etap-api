using System;
using System.ComponentModel.DataAnnotations;

namespace ETapManagement.ViewModel.Dto
{
	public class AddStrategicBusiness
	{
		public int Id { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[StringLength(200)]
		public string Name { get; set; }
		public bool? IsDelete { get; set; }
		public bool? IsActive { get; set; }
	}

	public class StrategicBusinessDetails
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDelete { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}

	public class StrategicBusinessCodeList
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}