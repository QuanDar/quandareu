
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using quaneu.datalayer.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace quaneu.datalayer
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<QuanUser> QuanUsers { get; set; }
    }
}
