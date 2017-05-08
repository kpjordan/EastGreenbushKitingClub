using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EastGreenbushKitingClub.ViewModels
{
    public class MemberEditViewModel
    {
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, Display(Name = "Date Joined"), DataType(DataType.DateTime)]
        public DateTime DateJoined { get; set; }

        [Required, Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "Street Address Line 2(Optional)")]
        public string StreetAddress2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required, Display(Name = "Zip Code"), DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Required, DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        public string ImageUrl { get; set; }
    }
}
