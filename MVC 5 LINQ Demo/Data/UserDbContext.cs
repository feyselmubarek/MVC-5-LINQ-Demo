using MVC_5_LINQ_Demo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_5_LINQ_Demo.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
    }
}