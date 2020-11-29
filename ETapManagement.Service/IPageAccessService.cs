using System;
using System.Collections.Generic;
using ETapManagement.Domain;
using ETapManagement.ViewModel.Dto;

namespace ETapManagement.Service {
    public interface IPageAccessService {
        List<PageAccess> GetPageAccess ();
        List<PageAccess> GetPageAccessBasedonRoleId (int roleId);

        ResponseMessage UpdatePageAccess (List<PageAccess> pageAccessDetails);

        List<Role> GetRoles ();
        RolesApplicationforms CheckRoleWiseAccess (int PageFormId, int userId);

    }
}