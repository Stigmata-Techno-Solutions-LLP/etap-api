using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository
{
	public interface IComponentRepository
	{
		List<ComponentDetails> GetComponent();
		ComponentDetails GetComponentById(int id);
		ResponseMessage AddComponent(ComponentDetails projectStructure);
		ResponseMessage UpdateComponent(ComponentDetails projectStructure, int id);
		ResponseMessage DeleteComponent(int id);
	}
}