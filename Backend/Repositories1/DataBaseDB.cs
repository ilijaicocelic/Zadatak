using Microsoft.EntityFrameworkCore;
using RepositoryServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class DataBaseDB : DbContext
    {
        public DataBaseDB(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
            if(this.Users.ToList().Where(x=>x.Role == Roles.Admin).Count() == 0)
            {
                User u1 = new User(Guid.NewGuid(), "Ilija", "Celic", "PR154-2016", 4, "2808997", "icocelic", Roles.Admin, Statuses.Regular);
                this.Users.Add(u1);
                this.SaveChanges();
            }
            
        }

        
       public DbSet<User> Users { get; set; }

       public DbSet<Course> Courses { get; set; }

    }
}
