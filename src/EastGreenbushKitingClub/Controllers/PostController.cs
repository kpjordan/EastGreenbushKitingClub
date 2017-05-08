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
    public class PostController : Controller
    {
        private IPostData _postData;
        private IMemberData _memberData;

        public PostController(IPostData postData, IMemberData memberData)
        {
            _postData = postData;
            _memberData = memberData;
        }

        public IActionResult Index()
        {
            var allPosts = _postData.GetAll().Where(p=> p.IsArchived == false);
            var model = new PostIndexViewModel();
            var list = new List<PostPreviewViewModel>();
            foreach (var post in allPosts)
            {
                var newModel = new PostPreviewViewModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Date = post.Date,
                    MemberName = post.Member.FirstName + " " + post.Member.LastName,
                    Content = post.Content.Substring(0, 2) + "..."
                };
                list.Add(newModel);
            }
            model.PostsPreview = list.OrderByDescending(p => p.Date);
            return View(model);
        }
    

        public IActionResult Details(int id)
        {
            var model = _postData.Get(id);
            return View(model);
        }

        [HttpGet, Authorize]
        public IActionResult Create()
        {
            var allMembers = _memberData.GetAll().Where(m => m.IsArchived == false);
            var list = new List<MemberPreviewViewModel>();
            foreach (var member in allMembers)
            {
                var newModel = new MemberPreviewViewModel()
                {
                    Id = member.Id,
                    Name = member.LastName + ", " + member.FirstName,
                    DateJoined = member.DateJoined
                };
                list.Add(newModel);
            }
            ViewBag.MemberList = list.OrderBy(m => m.Name);
            return View();
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public IActionResult Create(PostEditViewModel post)
        {
            if (ModelState.IsValid)
            {
                var newPost = new Post() { Title = post.Title, MemberId = post.MemberId, Content = post.Content, Date = post.Date };
                _postData.Add(newPost);
                return RedirectToAction("Details", new { id = newPost.Id });
            }

            return View();
        }

        [HttpGet, Authorize]
        public IActionResult Edit(int id)
        {
            var model = _postData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            var allMembers = _memberData.GetAll().Where(m => m.IsArchived == false);
            var list = new List<MemberPreviewViewModel>();
            foreach (var member in allMembers)
            {
                var newModel = new MemberPreviewViewModel()
                {
                    Id = member.Id,
                    Name = member.LastName + ", " + member.FirstName,
                    DateJoined = member.DateJoined
                };
                list.Add(newModel);
            }
            ViewBag.MemberList = list.OrderBy(m => m.Name);
            
            return View(model);
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PostEditViewModel post)
        {
           var model = _postData.Get(id);
            if (ModelState.IsValid)
            {
                model.Title = post.Title;
                model.Content = "Edited on" + post.Date + " " + post.Content;
                _postData.Commit();
                return RedirectToAction("Details", new { id = model.Id });
            }

            return View(post);
        }

        
        public IActionResult Archive(int id)
        {
            var model = _postData.Get(id);
            if (model != null && model.IsArchived == false)
            {
                model.IsArchived = true;
                _postData.Commit();

            }

            return RedirectToAction("Index");
        }
    }
}
