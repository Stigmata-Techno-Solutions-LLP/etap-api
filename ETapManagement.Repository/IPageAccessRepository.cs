using System.Collections.Generic;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
namespace ETapManagement.Repository {
    public interface IPageAccessRepository {
        List<PageAccess> GetPageAccess ();
        List<PageAccess> GetPageAccessBasedOnRoleId (int roleId);
        ResponseMessage UpdatePageAccess (List<PageAccess> pageAccessDetails);

        List<Role> GetRoles ();
        RolesApplicationforms CheckRoleWiseAccess (int PageFormId, int userId);

    }
}