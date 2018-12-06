using HiveStore.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiveStore.IService.Identity
{
    public interface IRoleService
    {
        Task<IdentityResult> SaveRole(RoleEntity identityRole);
        List<RoleEntity> GetAllRoles();
    }
}
