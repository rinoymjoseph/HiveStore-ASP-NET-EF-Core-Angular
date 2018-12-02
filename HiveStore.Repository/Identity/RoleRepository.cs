using HiveStore.DataAccess;
using HiveStore.IRepository.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HiveStore.Repository.Identity
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HiveDataContext _hiveDataContext;

        public RoleRepository(HiveDataContext hiveDataContext)
        {
            _hiveDataContext = hiveDataContext;
        }

        public List<IdentityRole> GetAllRoles()
        {
            return _hiveDataContext.Set<IdentityRole>().ToList();
        }

        public IdentityRole GetRoleById(string roleId)
        {
            return _hiveDataContext.Set<IdentityRole>().FirstOrDefault(x => x.Id == roleId);
        }
    }
}
