using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    class DataBaseDB : DbContext
    {
        public DataBaseDB(DbContextOptions options) : base(options)
        {
        }
    }
}
