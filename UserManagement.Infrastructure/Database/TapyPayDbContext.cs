using Microsoft.EntityFrameworkCore; 
using UserManagement.Domain.Aggregates.UsersAggregates;

namespace UserManagement.Infrastructure.Database
{
    public class TapyPayDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; } 
        public DbSet<Role> Roles { get; set; } 
        public DbSet<UserRole> UserRoles { get; set; } 
        public DbSet<Address> Address { get; set; } 

        public TapyPayDbContext(DbContextOptions<TapyPayDbContext> options)
            : base(options)
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
