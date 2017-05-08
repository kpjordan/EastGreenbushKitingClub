using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EastGreenbushKitingClub.Services.Interfaces;
using EastGreenbushKitingClub.ViewModels;
using EastGreenbushKitingClub.Models;

namespace EastGreenbushKitingClub.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }
    }
}
