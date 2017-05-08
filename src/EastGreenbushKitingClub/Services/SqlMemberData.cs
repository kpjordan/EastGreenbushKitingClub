using EastGreenbushKitingClub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EastGreenbushKitingClub.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;

namespace EastGreenbushKitingClub.Services
{
    public class SqlMemberData : IMemberData
    {
        private EastGreenbushKitingClubDbContext _context;

        public SqlMemberData(EastGreenbushKitingClubDbContext context)
        {
            _context = context;
        }
        public Member Add(Member m)
        {
            _context.Add(m);
            _context.SaveChanges();
            return m;

        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Member Get(int id)
        {
            return _context.Members.Include(member => member.Posts).FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Member> GetAll()
        {
            return _context.Members;
        }
    }
}
