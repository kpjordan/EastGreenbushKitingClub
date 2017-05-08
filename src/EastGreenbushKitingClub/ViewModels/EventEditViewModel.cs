using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EastGreenbushKitingClub.ViewModels
{
    public class EventEditViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Details { get; set; }
    }
}
