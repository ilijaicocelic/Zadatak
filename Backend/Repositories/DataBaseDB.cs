using Microsoft.EntityFrameworkCore;
using RepositoryServiceContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class DataBaseDB : DbContext
    {
        public DataBaseDB(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        DbSet<User> Users { get; set; }

        DbSet<Course> Courses { get; set; }

    }
}
