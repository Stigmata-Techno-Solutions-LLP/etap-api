using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.Repository
{
	public interface IAssignStructureComponentRepository
	{
		ResponseMessage UpsertProjectStructure(AssignStructureComponentDetails request);
	}
}
