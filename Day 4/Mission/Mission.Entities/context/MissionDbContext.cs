using Microsoft.EntityFrameworkCore;
using Mission.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.context
{
    public class MissionDbContext : DbContext
    {
        public MissionDbContext(DbContextOptions<MissionDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // ✅ Tell EF to use "Users" table name
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Anshul",
                LastName = "Panchal",
                EmailAddress = "anshulpanchal9099@gmail.com",
                UserType = "admin",
                Password = "Anshul@123",
                PhoneNumber = "9876543210",
                CreatedDate = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                ModifiedDate = DateTime.UtcNow,
                UserImage = "",
                IsDeleted = false
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
