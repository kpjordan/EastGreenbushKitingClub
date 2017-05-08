using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EastGreenbushKitingClub.Models
{
    public class EastGreenbushKitingClubDbContext : IdentityDbContext<User>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Post> Posts { get; set; }

        public EastGreenbushKitingClubDbContext(DbContextOptions options): base(options)
        {

        }
    }
}
