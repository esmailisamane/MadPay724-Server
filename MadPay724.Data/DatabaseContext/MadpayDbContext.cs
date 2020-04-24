﻿using MadPay724.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.DatabaseContext
{
  public  class MadpayDbContext: IdentityDbContext<User, Role, string,
      IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,IdentityRoleClaim<string> , IdentityUserToken<string>>
    {
        public MadpayDbContext()
        {
                
        }
        public MadpayDbContext(DbContextOptions<MadpayDbContext> opt): base(opt)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HO9R1KR\SA ;Initial Catalog = MadPay724db; Integrated Security= True; MultipleActiveResultSets=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }


    }
}
