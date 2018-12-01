using HiveStore.IRepository.Identity;
using HiveStore.IService.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiveStore.Service.Identity
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(IRoleRepository roleRepository, RoleManager<IdentityRole> roleManager) 
        {
            _roleRepository = roleRepository;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> SaveRole(IdentityRole identityRole)
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

        public List<IdentityRole> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }
    }
}
