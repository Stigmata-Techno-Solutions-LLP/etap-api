using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.ViewModel.Dto
{
	public class ProjectStructureDocumentDetails
	{
		public int Id { get; set; }
		public int ProjectStructureId { get; set; }
		public string FileName { get; set; }
		public string FileType { get; set; }
		public string Path { get; set; }
	}
}
