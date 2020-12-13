using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository
{
	public interface IStructureRepository
	{
		List<StructureDetails> GetStructure();
		StructureDetails GetStructureById(int id);
		ResponseMessage AddStructure(StructureDetails structure);
		ResponseMessage UpdateStructure(StructureDetails structure, int id);
		ResponseMessage DeleteStructure(int id);
	}
}