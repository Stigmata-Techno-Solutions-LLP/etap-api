using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.ViewModel.Dto
{
	public class AssignStructureComponentDetails
	{
		public ProjectStructureDetails ProjectStructureDetail { get; set; }
		public List<ComponentDetails> Components { get; set; }
		public List<ProjectStructureDocumentDetails> ProjectStructureDocumentDetails { get; set; }
	}
}
