using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {
    public interface IComponentTypeRepository
  {
        List<ComponentTypeDetails> getComponentType();
        ComponentTypeDetails getComponentTypeById(int id);
        ResponseMessage AddComponentType(ComponentTypeDetails componentType);
        ResponseMessage UpdateComponentType(ComponentTypeDetails ComponentType, int id);
        ResponseMessage DeleteComponentType(int id);
    }
}