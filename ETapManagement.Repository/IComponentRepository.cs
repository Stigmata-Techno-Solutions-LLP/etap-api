using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETapManagement.Repository
{
	public interface IComponentRepository
	{
		List<ComponentDetails> GetComponent();
	    List<ComponentDetails> GetComponentHistoryByCode(string compCode);

		ComponentDetails GetComponentById(int id);
		ResponseMessage AddComponents(AddComponents projectStructure);
		ResponseMessage UpdateComponent(ComponentDetails projectStructure, int id);
		ResponseMessage DeleteComponent(int id);
	}
}
