using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastGreenbushKitingClub.ViewModels
{
    public class PostPreviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MemberName { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
