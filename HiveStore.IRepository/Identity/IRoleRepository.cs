using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.IRepository.Identity
{
    public interface IRoleRepository
    {
        List<IdentityRole> GetAllRoles();
        IdentityRole GetRoleById(string userId);
    }
}
