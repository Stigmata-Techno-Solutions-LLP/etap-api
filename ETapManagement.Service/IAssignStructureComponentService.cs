using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.Service
{
	public interface IAssignStructureComponentService
	{
		ResponseMessage UpsertAssignStructureComponent(AssignStructureComponentDetails servicedto);
		AssignStructureDtlsOnly GetAssignStructureDtlsById(ComponentQueryParam filterReq);
		 List<AssignStructureDtlsOnly> GetAssignStructureDtls();

	}
}
