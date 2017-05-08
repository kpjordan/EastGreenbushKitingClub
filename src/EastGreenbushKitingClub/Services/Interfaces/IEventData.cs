using EastGreenbushKitingClub.Models;
using EastGreenbushKitingClub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastGreenbushKitingClub.Services.Interfaces
{
     public interface IEventData

    {
        IEnumerable<Event> GetAll();
        Event Get(int id);
        Event Add(Event e);
        void Commit();  
    }
}
