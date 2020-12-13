using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.ViewModel.Dto
{
	public class AssignStructureComponentDetails
	{
		public List<ComponentDetails> ComponentTypeDetails { get; set; }
		public List<ProjectStructureDetails> ProjectStructureDetails { get; set; }
		public List<ProjectStructureDocumentDetails> ProjectStructureDocumentDetails { get; set; }
	}
}
