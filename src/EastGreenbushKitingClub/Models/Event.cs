using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EastGreenbushKitingClub.Models
{
    public class Event
    {
        
        public int Id { get; set; } 

        [Required, Display(Name="Date and Time")]
        public DateTime Date { get; set; }

        [Required, MaxLength(50), MinLength(3)]
        public string Name { get; set; }

        [Required, MaxLength(50), MinLength(3)]
        public string Location { get; set; }

        [Required, MaxLength(1000)]
        public string Details { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public bool IsArchived { get; set; }
    }
}
