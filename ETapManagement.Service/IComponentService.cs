using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.Service
{
	public interface IComponentService
	{
		List<ComponentDetails> GetComponent( );
		List<ComponentDetails> GetComponentHistoryByCode(string compCode);

		ComponentDetails GetComponentById(int id);
		ResponseMessage AddComponent(ComponentDetails component);
		ResponseMessage UpdateComponent(ComponentDetails component, int id);
		ResponseMessage DeleteComponent(int id);
	}
}
