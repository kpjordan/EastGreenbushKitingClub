using EastGreenbushKitingClub.Models;
using EastGreenbushKitingClub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EastGreenbushKitingClub.Services
{
    public class SqlEventData : IEventData
    {
        private EastGreenbushKitingClubDbContext _context;

        public SqlEventData(EastGreenbushKitingClubDbContext context)
        {
            _context = context;
        }

        public Event Add(Event e)
        {
            _context.Add(e);
            _context.SaveChanges();
            return e;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Event Get(int id)
        {
            return _context.Events.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events;
        }

    }
}
