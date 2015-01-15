namespace BullsAndCows.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using BullsAndCows.Data.Migrations;
    using BullsAndCows.Models;

    public class BullsAndCowsDbContext : IdentityDbContext<ApplicationUser>
    {
        public BullsAndCowsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
        }
        
        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public IDbSet<Guess> Guesses { get; set; }
    }
}
