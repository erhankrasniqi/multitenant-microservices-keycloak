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

             modelBuilder.Entity<Users>()
                .HasIndex(u => u.TenantId)
                .HasDatabaseName("IX_Users_TenantId");

            modelBuilder.Entity<Users>()
                .HasIndex(u => u.KeycloakId)
                .IsUnique()
                .HasDatabaseName("IX_Users_KeycloakId");
              
            modelBuilder.Entity<UserRole>()
                .HasIndex(ur => ur.RoleId)
                .HasDatabaseName("IX_UserRoles_RoleId");
             
            modelBuilder.Entity<UserRole>()
                .HasIndex(ur => ur.UserId)
                .HasDatabaseName("IX_UserRoles_UserId");

             
            modelBuilder.Entity<Address>()
                .HasIndex(a => a.Country)
                .HasDatabaseName("IX_Address_Country");
        }

    }
}
