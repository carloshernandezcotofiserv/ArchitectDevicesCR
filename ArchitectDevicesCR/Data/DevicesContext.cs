using Microsoft.EntityFrameworkCore;

namespace ArchitectDevicesCR.DataModels
{
    public class DevicesContext : DbContext
    {
        public DevicesContext(DbContextOptions<DevicesContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
        //}

        public DbSet<ArchitectDevicesCR.DataModels.Checkout> Checkouts { get; set; }
        public DbSet<ArchitectDevicesCR.DataModels.CheckoutHistory> CheckoutHistories { get; set; }
        public DbSet<ArchitectDevicesCR.DataModels.Device> Devices { get; set; }
        public DbSet<ArchitectDevicesCR.DataModels.Hold> Holds { get; set; }
        public DbSet<ArchitectDevicesCR.DataModels.Site> Sites { get; set; }
        public DbSet<ArchitectDevicesCR.DataModels.Status> Statuses { get; set; }
        public DbSet<ArchitectDevicesCR.DataModels.User> Users { get; set; }
        //public DbSet<ArchitectDevicesCR.DataModels.UserCard> UserCards { get; set; }
        //public DbSet<ArchitectDevicesCR.DataModels.Role> Roles { get; set; }
        //public DbSet<ArchitectDevicesCR.DataModels.UserRole> UserRoles { get; set; }

    }
}
