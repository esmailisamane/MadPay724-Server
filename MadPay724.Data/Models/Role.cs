using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MadPay724.Data.Models
{
   public class Role: IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
