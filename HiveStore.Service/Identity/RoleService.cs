using HiveStore.Entity.Identity;
using HiveStore.IRepository.Identity;
using HiveStore.IService.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiveStore.Service.Identity
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleManager<RoleEntity> _roleManager;

        public RoleService(IRoleRepository roleRepository, RoleManager<RoleEntity> roleManager) 
        {
            _roleRepository = roleRepository;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> SaveRole(RoleEntity identityRole)
        {
            try
            {
                var result = await _roleManager.CreateAsync(identityRole);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RoleEntity> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }
    }
}
