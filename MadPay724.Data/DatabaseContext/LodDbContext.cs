﻿using MadPay724.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MadPay724.Data.DatabaseContext
{
 public   class LodDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HO9R1KR\SA ;Initial Catalog =Logdb; Integrated Security= True; MultipleActiveResultSets=True");
        }
        public DbSet<Log> Logs { get; set; }
    }
}
