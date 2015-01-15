namespace BullsAndCows.Data
{
    using System;

    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public interface IGamesData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Game> Games { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Guess> Guesses { get; }

        int SaveChanges();
    }
}
