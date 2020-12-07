using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ETapManagement.ViewModel.Dto
{
	public class ComponentTypeDetails
	{
		public int Id { get; set; }
		
		[Required]
        [DataType (DataType.Text)]
        [StringLength (200)]
        [Display (Name = "Component Name")]
		public string Name { get; set; }
        [DataType (DataType.Text)]
        [StringLength (500)]
        [Display (Name = "Component Description")]
		public string Description { get; set; }
		
		[Required]
        [Display (Name = "Status")]
		public bool isActive { get; set; }
	}

	public class ComponentTypeRequest
	{

	}

	public class ComponentTypeResponse
	{

	}
}