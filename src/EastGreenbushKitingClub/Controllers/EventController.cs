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
    public class EventController : Controller

    {
        private IEventData _eventData;

        public EventController(IEventData eventData)
        {
            _eventData = eventData;
        }
        
        public IActionResult Index()
        {
            var allEvents = _eventData.GetAll().Where(e=> e.IsArchived == false).Where(e=> e.Date > DateTime.Today);
            var model = new EventIndexViewModel();
            var list = new List<EventPreviewViewModel>();
            foreach (var e in allEvents)
            {
                var newModel = new EventPreviewViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Date = e.Date
                };
                list.Add(newModel);
            }
            model.EventPreview = list.OrderByDescending(m => m.Date);
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _eventData.Get(id);
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
        public IActionResult Create(EventEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newEvent = new Event()
                {   Name = model.Name,
                    Details = model.Details,
                    Date = model.Date,
                    Location = model.Location,
                    IsArchived =false};
                newEvent = _eventData.Add(newEvent);
                _eventData.Commit();
                return RedirectToAction("Details", new {id = newEvent.Id });
            }

            return View();
        }

        [HttpGet, Authorize]
        public IActionResult Edit(int id)
        {
            var model = _eventData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EventEditViewModel e)
        {
            var model = _eventData.Get(id);
            if (ModelState.IsValid)
            {
                model.Date = e.Date;
                model.Details = e.Details;
                model.Location = e.Location;
                model.Name = e.Name;
                _eventData.Commit();
                return RedirectToAction("Details", new { id = model.Id });
            }

            return View(e);
        }

        
        public IActionResult Archive(int id)
        {
            var model = _eventData.Get(id);
            if (model != null && model.IsArchived == false)
            {
                model.IsArchived = true;
                _eventData.Commit();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Details", new { id = model.Id});
        }
    }
}
