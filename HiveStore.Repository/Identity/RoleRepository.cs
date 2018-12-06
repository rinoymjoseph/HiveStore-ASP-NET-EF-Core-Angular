using HiveStore.DataAccess;
using HiveStore.Entity.Identity;
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

        public List<RoleEntity> GetAllRoles()
        {
            return _hiveDataContext.Set<RoleEntity>().ToList();
        }

        public RoleEntity GetRoleById(int roleId)
        {
            return _hiveDataContext.Set<RoleEntity>().FirstOrDefault(x => x.Id == roleId);
        }
    }
}
