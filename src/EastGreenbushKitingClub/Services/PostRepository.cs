using EastGreenbushKitingClub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using EastGreenbushKitingClub.Models;

namespace EastGreenbushKitingClub.Services
{
    public class PostRepository : IPostData

    {
        public Post Add(Post p)
        {
            p.Id = _posts.Count + 1;
            _posts.Add(p);
            return p;
        }

        public Post Get(int id)
        {
            return _posts.FirstOrDefault(p => p.Id == id);
        }

        public Post GetLast()
        {
            return _posts.Last();
        }

        public IEnumerable<Post> GetAll()
        {
            return _posts;
        }

        public void Commit()
        {
            // nothing happens
        }

        private List<Post> _posts = new List<Post>
            {
                new Post {Id = 1, MemberId= 4, Title="Hello", Content="Hello and welcome to the page!", Date= new DateTime(2017, 04, 07, 00, 00, 00) },
                new Post {Id = 2, MemberId= 1, Title="Big Events Coming!", Content="We have some exciting upcoming events", Date= new DateTime(2017, 04, 16, 00,00,00) },
                new Post {Id = 3, MemberId= 4, Title="News", Content="Just some news for our members", Date= new DateTime(2017, 04, 21, 00, 00, 00) },
                new Post {Id = 4, MemberId= 1, Title="Rain Cancellation", Content= "Oh no, the event has been cancelled due to rain", Date= new DateTime(2017, 04, 28, 00,00,00) }
            };

            
    }
}
