using EastGreenbushKitingClub.Models;
using EastGreenbushKitingClub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastGreenbushKitingClub.Services.Interfaces
{
    public interface IPostData
    {
        IEnumerable<Post> GetAll();        
        Post Get(int id);
        Post Add(Post p);
        void Commit();
    }
}
