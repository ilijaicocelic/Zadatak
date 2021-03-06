using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryServiceContract
{
    public interface IUserRepository
    {
         User GetUser(Guid Id);

        void UpdateUser(User user);

        IEnumerable<User> GetAllUsers();

        Guid AddUser(User user);



    }
}
