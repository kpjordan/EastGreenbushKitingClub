using EastGreenbushKitingClub.Models;
using EastGreenbushKitingClub.Services.Interfaces;
using EastGreenbushKitingClub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastGreenbushKitingClub.Controllers
{
    public class MemberController : Controller
    {
        private IMemberData _memberData;

        public MemberController(IMemberData memberData)
        {
            _memberData = memberData;
        }
        public IActionResult Index()
        {
            var allMembers = _memberData.GetAll().Where(m=> m.IsArchived == false);
            var model = new MemberIndexViewModel();
            var list = new List<MemberPreviewViewModel>();
            foreach (var member in allMembers )
            {
                var newModel = new MemberPreviewViewModel()
                {
                    Id = member.Id,
                    Name = member.LastName + ", " + member.FirstName,
                    DateJoined = member.DateJoined
                };
                list.Add(newModel);
            }
            model.MembersPreview = list.OrderBy(m => m.Name);

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _memberData.Get(id);
            if (model == null)
            {

                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        [HttpGet, Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        
        public IActionResult Create(MemberEditViewModel member)
        {
            if (ModelState.IsValid)
            {
                var newMember = new Member()
                { FirstName = member.FirstName,
                    LastName =member.LastName,
                    StreetAddress = member.StreetAddress,
                    StreetAddress2 = member.StreetAddress2,
                    City =member.City,
                    State =member.State,
                    ZipCode =member.ZipCode,
                    DateJoined = member.DateJoined,
                    ImageUrl = member.ImageUrl,
                    Telephone = member.Telephone,
                    IsArchived =false };
                _memberData.Add(newMember);
                _memberData.Commit();
                return RedirectToAction("Details", new { id = newMember.Id });
            }
            return View();
        }

        [HttpGet, Authorize]
        public IActionResult Edit(int id)
        {
            var model = _memberData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MemberEditViewModel member)
        {
            var model = _memberData.Get(id);
            if (ModelState.IsValid)
            {
                model.FirstName = member.FirstName;
                model.LastName = member.LastName;
                model.StreetAddress = member.StreetAddress;
                model.StreetAddress2 = member.StreetAddress2;
                model.City = member.City;
                model.State = member.State;
                model.ZipCode = member.ZipCode;
                model.Telephone = member.Telephone;
                model.ImageUrl = member.ImageUrl;
                model.DateJoined = member.DateJoined;
                _memberData.Commit();
                return RedirectToAction("Details", new { id = model.Id });
            }
            return View(member);
        }

        
        public IActionResult Archive(int id)
        {
            var model = _memberData.Get(id);
            if (model != null && model.IsArchived == false)
            {
                model.IsArchived = true;
                
            }

            return RedirectToAction("Index");
        }
    }
}
