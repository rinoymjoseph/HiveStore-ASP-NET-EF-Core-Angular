using HiveStore.IRepository.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.Repository.Identity
{
    public class RoleRepository : IRoleRepository
    {
        public List<IdentityRole> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public IdentityRole GetRoleById(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
