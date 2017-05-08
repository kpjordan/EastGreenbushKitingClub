using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EastGreenbushKitingClub.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required, MaxLength(25)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password), MaxLength(25)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), MaxLength(25), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        public int MemberId { get; set; }
    }
}
