using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EastGreenbushKitingClub.Models
{
    public class Post
    {

        public int Id { get; set; } 

        [Required, Display(Name = "Author")]
        public int MemberId { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, MinLength(3), MaxLength(5000)]
        public string Content { get; set; }

        [Required]
        public bool IsArchived { get; set; }

        public Member Member { get; set; }
    }


}
