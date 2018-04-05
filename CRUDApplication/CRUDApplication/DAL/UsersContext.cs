using CRUDApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDApplication.DAL
{
    public class UsersContext:DbContext
    {
        public UsersContext() : base("name=myConnString") { }
        public DbSet<Users> Users { get; set; }
    }
}