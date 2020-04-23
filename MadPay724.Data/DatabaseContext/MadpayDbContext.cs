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

        public DbSet<Photo> Photos { get; set; }
        public DbSet<BankCard> BankCards { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}
