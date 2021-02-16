using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestingProject1.Models;

namespace TestingProject1.EFContext
{
    public class EfDbContext :DbContext
    {
        public EfDbContext() : base("EFDbContext")
        {

        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}