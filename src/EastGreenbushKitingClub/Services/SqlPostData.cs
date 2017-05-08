using EastGreenbushKitingClub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EastGreenbushKitingClub.Models;
using Microsoft.EntityFrameworkCore;

namespace EastGreenbushKitingClub.Services
{
    public class SqlPostData : IPostData
    {
        private EastGreenbushKitingClubDbContext _context;

        public SqlPostData(EastGreenbushKitingClubDbContext context)
        {
            _context = context;
        }
        public Post Add(Post p)
        {
            _context.Add(p);
            _context.SaveChanges();
            return p;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Post Get(int id)
        {
            return _context.Posts.Include(post=> post.Member).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.Include(post=> post.Member);
        }
    }
}
