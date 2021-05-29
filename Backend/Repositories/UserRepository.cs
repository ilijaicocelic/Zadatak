using RepositoryServiceContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public Guid AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
