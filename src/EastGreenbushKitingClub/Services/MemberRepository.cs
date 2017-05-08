using EastGreenbushKitingClub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EastGreenbushKitingClub.Models;
using EastGreenbushKitingClub.ViewModels;

namespace EastGreenbushKitingClub.Services
{
    public class MemberRepository : IMemberData
    {
        public Member Add(Member m)
        {
            m.Id = _members.Max(e=> e.Id) + 1;
            m.ImageUrl = "~/images/5.jpg";
            _members.Add(m);
            return m;
        }

        public Member Get(int id)
        {
            return _members.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Member> GetAll()
        {
            return _members;
        }

        public void Commit()
        {
            // nothing happens
        }

        private List<Member> _members = new List<Member>
            {
                new Member {Id= 1, FirstName="Valarie", LastName="Curtain",
                    StreetAddress ="131 Fairlawn Avenue",
                    StreetAddress2="Apt 3B",
                    City="South Greenbush",
                    State="NY",
                    ZipCode="12222",
                    DateJoined = new DateTime(2008, 10, 08, 00, 00, 00),
                    Telephone ="555-123-4567",
                    ImageUrl ="images/5.jpg",
                    IsArchived =false},
                new Member {Id= 2, FirstName="Stephen", LastName="Farlane",
                    StreetAddress ="23 Rock Quarry Road",
                    City="Barnhill",
                    State="NY",
                    ZipCode="12444",
                    DateJoined = new DateTime(2006, 05, 28, 00, 00, 00),
                    Telephone ="555-555-1111",
                    ImageUrl ="images/5.jpg",
                    IsArchived =false },
                new Member {Id= 3, FirstName="Latoya", LastName="Crescent",
                    StreetAddress ="1596 Winchester Parkway",
                    City="Malavia",
                    State="NY",
                    ZipCode="12322",
                    DateJoined = new DateTime(2015, 03, 15, 00, 00, 00),
                    Telephone ="555-999-0001",
                    ImageUrl ="images/5.jpg",
                    IsArchived =false },
                new Member {Id= 4, FirstName="Merrell", LastName="St Augustine",
                    StreetAddress ="170 Ashbury Drive",
                    City="Boulard",
                    State="NY",
                    ZipCode="12227",
                    DateJoined = new DateTime(2002, 09, 23, 00, 00, 00),
                    Telephone ="555-122-3822",
                    ImageUrl ="images/5.jpg",
                    IsArchived =false}
            };

            
    }
}
