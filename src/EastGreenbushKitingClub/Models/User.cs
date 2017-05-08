using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastGreenbushKitingClub.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            
        }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
