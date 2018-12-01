using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiveStore.IService.Identity
{
    public interface IRoleService
    {
        Task<IdentityResult> SaveRole(IdentityRole identityRole);
        List<IdentityRole> GetAllRoles();
    }
}
