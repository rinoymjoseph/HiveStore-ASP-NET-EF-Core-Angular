using HiveStore.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiveStore.IService.Identity
{
    public interface IUserService
    {
        Task<IdentityResult> SaveUser(UserEntity userEntity);
        List<UserEntity> GetAllUsers();
        UserEntity GetUserById(string userId);
        Task<IdentityResult> AddAdminUser();
    }
}
