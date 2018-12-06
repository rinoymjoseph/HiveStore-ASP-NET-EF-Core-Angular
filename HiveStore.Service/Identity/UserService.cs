using HiveStore.DTO;
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
        private readonly RoleManager<RoleEntity> _roleManager;

        public UserService(IUserRepository userRepository, UserManager<UserEntity> userManager,
            RoleManager<RoleEntity> roleManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> SaveUser(UserDTO userDTO)
        {
            try
            {
                UserEntity _userEntity_saved = _userRepository.GetUserById(userDTO.Id);
                if (_userEntity_saved == null)
                {
                    UserEntity _userEntity = new UserEntity();
                    MapUserDTOToUserEntity(userDTO, _userEntity);
                    _userEntity.CreatedBy = System.Environment.UserName;
                    _userEntity.CreatedDate = DateTime.Now;
                    return await _userManager.CreateAsync(_userEntity, userDTO.Password);
                }
                else
                {
                    MapUserDTOToUserEntity(userDTO, _userEntity_saved);
                    var newPassword = _userManager.PasswordHasher.HashPassword(_userEntity_saved, userDTO.Password);
                    _userEntity_saved.PasswordHash = newPassword;
                    return await _userManager.UpdateAsync(_userEntity_saved);
                }                            
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
                RoleEntity identityRole = new RoleEntity();
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

        private void MapUserDTOToUserEntity(UserDTO userDTO, UserEntity userEntity)
        {
            userEntity.UserName = userDTO.UserName;
            userEntity.FirstName = userDTO.FirstName;
            userEntity.LastName = userDTO.LastName;
            userEntity.Country = userDTO.Country;
            userEntity.City = userDTO.City;
            userEntity.ModifiedBy = System.Environment.UserName;
            userEntity.ModifiedDate = DateTime.Now;
        }
    }
}
