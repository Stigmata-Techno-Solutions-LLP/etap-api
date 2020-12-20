using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.Repository
{
	public interface IAssignStructureComponentRepository
	{
		int UpsertProjectStructure(AssignStructureComponentDetails request);
		bool StructureRemoveDocs(string request);
		bool StructureDocsUpload(Upload_Docs request,int Id);

	}
}
