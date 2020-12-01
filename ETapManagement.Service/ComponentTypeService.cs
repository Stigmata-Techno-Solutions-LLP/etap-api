using System.Collections.Generic;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Repository;
using Microsoft.Extensions.Options;

namespace ETapManagement.Service
{
  public class ComponentTypeService : IComponentTypeService
  {
    IComponentTypeRepository _componentTypeRepository;

        private readonly AppSettings _appSettings;

        public ComponentTypeService(IOptions<AppSettings> appSettings, IComponentTypeRepository componentTypeRepository) {
            _componentTypeRepository = componentTypeRepository;
            _appSettings = appSettings.Value;
        }

        public List<ComponentTypeDetails> getComponentType() {
            List<ComponentTypeDetails> componentTypes = _componentTypeRepository.getComponentType();
            if (!(componentTypes?.Count > 0)) return null;

            return componentTypes;
        }

        public ComponentTypeDetails getComponentTypeById(int id) {
            ComponentTypeDetails componentType = _componentTypeRepository.getComponentTypeById(id);
            if (componentType == null) return null;

            return componentType;
        }

        public ResponseMessage AddComponentType(ComponentTypeDetails componentType) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _componentTypeRepository.AddComponentType(componentType);

            if (responseMessage != null) //TODO
                return responseMessage;
            else {
                return new ResponseMessage () {
                    Message = "",
                };
            }
        }

        public ResponseMessage UpdateComponentType(ComponentTypeDetails componentType, int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _componentTypeRepository.UpdateComponentType(componentType, id);
            return responseMessage;
        }

        public ResponseMessage DeleteComponentType(int id) {
            ResponseMessage responseMessage = new ResponseMessage ();
            responseMessage = _componentTypeRepository.DeleteComponentType(id);
            return responseMessage;
        }
  }
}