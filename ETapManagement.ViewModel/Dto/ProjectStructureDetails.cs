using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.ViewModel.Dto
{
	public class ProjectStructureDetails
	{
		public int Id { get; set; }
		public int? StructureId { get; set; }
		public int? ProjectId { get; set; }
		public string DrawingNo { get; set; }
		public int? ComponentsCount { get; set; }
		public bool? IsDelete { get; set; }
	}
}
