﻿using EastGreenbushKitingClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastGreenbushKitingClub.ViewModels
{
    public class PostIndexViewModel
    {
        public IEnumerable<PostPreviewViewModel> PostsPreview { get; set; }

    }
}
