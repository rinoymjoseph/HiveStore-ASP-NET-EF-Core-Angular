using HiveStore.Entity.Identity;
using System.Collections.Generic;

namespace HiveStore.IRepository.Identity
{
    public interface IUserRepository
    {
        void AddUser(UserEntity userEntity);
        List<UserEntity> GetAllUsers();
        UserEntity GetUserById(string userId);
        string SaveChanges();
    }
}
