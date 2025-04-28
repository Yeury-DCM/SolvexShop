﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolvexShop.Infrastructure.Identity.Entities;


namespace SolvexShop.Infrastructure.Identity.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        }   
    }
}
