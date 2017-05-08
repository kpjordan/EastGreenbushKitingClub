using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EastGreenbushKitingClub.Models
{
    public class Member
    {

        public int Id { get; set; }

        public IList<Post> Posts { get; set; }

        

        [Required, MinLength(3), MaxLength(50), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(50), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; }

        [Required, MinLength(5), MaxLength(100), Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [MaxLength(100), Display(Name = "Street Address Line 2 (Optional)")]
        public string StreetAddress2 { get; set; }

        [Required, MinLength(2), MaxLength(100)]
        public string City { get; set; }

        [Required, MaxLength(2), MinLength(2)]
        public string State { get; set; }

        [Required, MinLength(5), MaxLength(5), DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }


        [Required, MaxLength(20), MinLength(7), DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
