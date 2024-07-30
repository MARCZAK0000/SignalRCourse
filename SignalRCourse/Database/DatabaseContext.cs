using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace SignalRCourse.Database
{
    public class DatabaseContext : IdentityDbContext<Account>
    { 
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<User> Users {  get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");
            });
            modelBuilder.Entity<User>(pr => {

                pr.HasKey(pr => pr.AccountID);

                pr.HasOne(u => u.Account)
                .WithOne(pr => pr.User)
                .HasForeignKey<Account>(pr => pr.Id);


                pr.HasMany(pr => pr.Notifications)
                .WithOne(pr => pr.User)
                .HasForeignKey(pr => pr.AccountId);
            });
                

            base.OnModelCreating(modelBuilder);
        }
    }
}
