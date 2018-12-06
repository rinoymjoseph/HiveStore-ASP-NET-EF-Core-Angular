using HiveStore.Entity.Identity;
using System.Collections.Generic;

namespace HiveStore.IRepository.Identity
{
    public interface IRoleRepository
    {
        List<RoleEntity> GetAllRoles();
        RoleEntity GetRoleById(int userId);
    }
}
