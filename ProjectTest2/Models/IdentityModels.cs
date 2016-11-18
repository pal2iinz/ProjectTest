using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProjectTest2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int PositionID { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

      

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

       

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Rename Table-Colunm Field//
            modelBuilder.Entity<ApplicationUser>().ToTable("Account").Property(p => p.Id).HasColumnName("UserID");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AccountPosition").Property(p => p.RoleId).HasColumnName("PositionID");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            

            modelBuilder.Entity<ApplicationUser>().Ignore(c => c.AccessFailedCount)
                                       .Ignore(c => c.LockoutEnabled)
                                       .Ignore(c => c.LockoutEndDateUtc)
                                       .Ignore(c => c.TwoFactorEnabled);

           
        }
    }
}