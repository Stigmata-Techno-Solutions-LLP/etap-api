using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ETapManagement.ViewModel.Dto
{
	public class ComponentTypeDetails
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool isActive { get; set; }
	}

	public class ComponentTypeRequest
	{

	}

	public class ComponentTypeResponse
	{

	}
}