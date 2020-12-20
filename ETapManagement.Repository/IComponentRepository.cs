﻿using ETapManagement.ViewModel.Dto;
using System;
using System.Collections.Generic;
using System.Text;

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