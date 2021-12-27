
using Microsoft.EntityFrameworkCore;
using Model.API;
using System;

namespace Database.API
{
    public class DbContextModel : DbContext
    {
        public DbContextModel(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
    }
}
