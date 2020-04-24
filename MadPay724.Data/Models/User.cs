﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MadPay724.Data.Models
{
  public  class User: IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [StringLength(100, MinimumLength = 0)]
        public string Name { get; set; }
     
     
        [Required]
        [StringLength(500, MinimumLength = 0)]
        public string Address { get; set; }

        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime LastActive { get; set; }
        [StringLength(100, MinimumLength = 0)]
        public string City { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool Status { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<BankCard> BankCards { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
