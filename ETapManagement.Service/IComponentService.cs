using System;
using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service
{
	public interface IComponentService
	{
		List<ComponentDetails> GetComponent();
		ComponentDetails GetComponentById(int id);
		ResponseMessage AddComponent(ComponentDetails component);
		ResponseMessage UpdateComponent(ComponentDetails component, int id);
		ResponseMessage DeleteComponent(int id);
	}
}