using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Repository {
    public interface IComponentRepository {
        List<ComponentDetails> GetComponent ();
        List<ComponentDetails> GetComponentHistoryByCode (string compCode);

        ComponentDetails GetComponentById (int id);
        ResponseMessage AddComponents (AddComponents projectStructure);
         ResponseMessage AddComponentsDisaptch (DispatchAddComponents request);

        ResponseMessage UpdateComponent (ComponentDetails projectStructure, int id);
        ResponseMessage DeleteComponent (int id);
    }
}