using EastGreenbushKitingClub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EastGreenbushKitingClub.Models;
using EastGreenbushKitingClub.ViewModels;

namespace EastGreenbushKitingClub.Services
{
    public class EventRepository : IEventData

    {
        public Event Add(Event e)
        {
            e.Id = _events.Count + 1;
            e.ImageUrl = "~/images/460.jpg";
            _events.Add(e);
            return e;
        }

        public Event Get(int id)
        {
            return _events.FirstOrDefault(e=> e.Id == id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _events;
        }

        public void Commit()
        {
            // nothing happens
        }

        private List<Event> _events = new List<Event>
        {
                new Event {Id= 1, Name="Sunshine Kite Fest", Date= new DateTime(2017, 04, 28, 10, 00, 00), Location="Town Park", Details="Come on out!", ImageUrl="images/460.jpg" },
                new Event {Id= 2, Name="Kids' Kite Day", Date= new DateTime(2017, 05, 22, 12, 00, 00), Location="Shell Pond", Details="Come on out!", ImageUrl="images/460.jpg"},
                new Event {Id= 3, Name="2017 Kite Expo", Date= new DateTime(2017, 06, 01, 09, 00, 00), Location="Hinson Convention Center", Details="Come on out!", ImageUrl="images/460.jpg"},
                new Event {Id= 4, Name="Battle of the Kites", Date= new DateTime(2017, 07, 27, 10, 30, 00), Location="Town Park", Details="Come on out!", ImageUrl="images/460.jpg" }
        };


    }
}
