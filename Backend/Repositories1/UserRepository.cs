using RepositoryServiceContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private DataBaseDB _context;
     
        public UserRepository(DataBaseDB dataContext)
        {
            _context = dataContext;
        }
        public Guid AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetUser(Guid Id)
        {
            return _context.Users.Find(Id);
        }

        public void UpdateUser(User user)
        {
            User userForUpdate = _context.Users.Find(user.Id);

            if (userForUpdate == null)
            {
                throw new KeyNotFoundException();
            }
            userForUpdate.Name = user.Name;
            userForUpdate.Surname = user.Surname;
            userForUpdate.IndexNumber = user.IndexNumber;
            userForUpdate.Username = user.Username;
            userForUpdate.Password = user.Password;
            userForUpdate.Status = user.Status;
            userForUpdate.Year = user.Year;
           
                _context.Entry(userForUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
    }
}
