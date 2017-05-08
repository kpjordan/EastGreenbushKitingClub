using EastGreenbushKitingClub.Models;
using EastGreenbushKitingClub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EastGreenbushKitingClub.Services.Interfaces
{
    public interface IMemberData
    {
        IEnumerable<Member> GetAll();
        Member Get(int id);
        Member Add(Member m);
        void Commit();

    }
}
