using System;
using System.Collections.Generic;
using System.Text;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IComponentService {
        List<ComponentDetails> GetComponent ();
        List<ComponentDetails> GetComponentHistoryByCode (string compCode);

        ComponentDetails GetComponentById (int id);
        ResponseMessage AddComponents (AddComponents component);
        ResponseMessage UpdateComponent (ComponentDetails component, int id);
        ResponseMessage DeleteComponent (int id);
    }
}