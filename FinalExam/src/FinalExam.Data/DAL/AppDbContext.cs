using FinalExam.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Data.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Service> Services { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                var entity = data.Entity;

                switch (data.State)
                {
                    case EntityState.Added:
                        entity.CreatedDate = DateTime.UtcNow.AddHours(4);
                        entity.UpdatedDate = DateTime.UtcNow.AddHours(4);
                        break;
                    case EntityState.Modified:
                        entity.UpdatedDate = DateTime.UtcNow.AddHours(4);
                        break;
                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
