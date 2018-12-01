using HiveStore.DataAccess;
using HiveStore.Entity.Identity;
using HiveStore.IRepository.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HiveStore.Repository.Identity
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly HiveDataContext HiveDataContext;
        public UserRepository(HiveDataContext hiveDataContext) : base(hiveDataContext)
        {
            HiveDataContext = hiveDataContext;
        }

        public void AddUser(UserEntity userEntity)
        {
            if (userEntity == null)
            {
                throw new ArgumentNullException("userEntity");
            }

            var set = HiveDataContext.Set<UserEntity>();
            set.Add(userEntity);
        }

        public List<UserEntity> GetAllUsers()
        {
            return HiveDataContext.Set<UserEntity>().ToList();
        }

        public UserEntity GetUserById(string userId)
        {
            return HiveDataContext.Set<UserEntity>().FirstOrDefault(x => x.Id.Equals(userId));
        }
    }
}
