using HiveStore.Entity.Identity;
using HiveStore.IRepository.Identity;
using HiveStore.IService.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiveStore.Service.Identity
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IUserRepository userRepository, UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> SaveUser(UserEntity userEntity)
        {
            try
            {
                UserEntity _userEntity = new UserEntity();
                _userEntity.FirstName = "Rinoy";
                _userEntity.LastName = "Joseph";
                _userEntity.UserName = "rinoy";
                _userEntity.CreatedBy = System.Environment.UserName;
                _userEntity.ModifiedBy = System.Environment.UserName;
                _userEntity.CreatedDate = DateTime.Now;
                _userEntity.ModifiedDate = DateTime.Now;
                var result = await _userManager.CreateAsync(_userEntity, "Samtron@1");
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<UserEntity> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public UserEntity GetUserById(string userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public async Task<IdentityResult> AddAdminUser()
        {
            try
            {
                UserEntity _userEntity = new UserEntity();
                _userEntity.FirstName = "Admin";
                _userEntity.LastName = "Admin";
                _userEntity.UserName = "admin";
                _userEntity.CreatedBy = System.Environment.UserName;
                _userEntity.ModifiedBy = System.Environment.UserName;
                _userEntity.CreatedDate = DateTime.Now;
                _userEntity.ModifiedDate = DateTime.Now;
                var result_user = await _userManager.CreateAsync(_userEntity, "admin");
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name = "Admin";
                var result_role = await _roleManager.CreateAsync(identityRole);
                var result = await _userManager.AddToRoleAsync(_userEntity, "Admin");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
