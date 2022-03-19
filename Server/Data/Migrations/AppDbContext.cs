using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Data.Models;

namespace Server.Data.Migrations
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cat>(entity =>{
                entity.HasOne(c=>c.User).WithMany(u=>u.Cats).HasForeignKey(c=>c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            base.OnModelCreating(builder);
        }
        
    }
}