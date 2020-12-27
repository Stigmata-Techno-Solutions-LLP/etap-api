using System;
using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IComponentTypeService {
        List<ComponentTypeDetails> GetComponentType ();
        ComponentTypeDetails GetComponentTypeById (int id);
        ResponseMessage AddComponentType (ComponentTypeDetails componentTypeDetails);
        ResponseMessage UpdateComponentType (ComponentTypeDetails componentTypeDetails, int id);
        ResponseMessage DeleteComponentType (int id);
    }
}