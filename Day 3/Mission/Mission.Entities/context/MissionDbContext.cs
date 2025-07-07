using Microsoft.EntityFrameworkCore;
using Mission.Entities.Entities;

namespace Mission.Entities.context
{
    public class MissionDbContext : DbContext
    {
        public MissionDbContext(DbContextOptions<MissionDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Fix typo in legacy timestamp setting
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // ✅ Explicitly set table name
            modelBuilder.Entity<User>().ToTable("Users");

            // ✅ Seed initial admin user
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Tatva",
                LastName = "Admin",
                EmailAddress = "anshulpanchal9099@gmail.com",
                UserType = "admin",
                Password = "Anshul@123",
                PhoneNumber = "9586842005",
                CreatedDate = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
