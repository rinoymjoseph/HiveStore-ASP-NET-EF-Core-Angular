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
        private readonly HiveDataContext _hiveDataContext;
        public UserRepository(HiveDataContext hiveDataContext) : base(hiveDataContext)
        {
            _hiveDataContext = hiveDataContext;
        }

        public void AddUser(UserEntity userEntity)
        {
            if (userEntity == null)
            {
                throw new ArgumentNullException("userEntity");
            }

            var set = _hiveDataContext.Set<UserEntity>();
            set.Add(userEntity);
        }

        public List<UserEntity> GetAllUsers()
        {
            return _hiveDataContext.Set<UserEntity>().ToList();
        }

        public UserEntity GetUserById(string userId)
        {
            return _hiveDataContext.Set<UserEntity>().FirstOrDefault(x => x.Id.Equals(userId));
        }
    }
}
