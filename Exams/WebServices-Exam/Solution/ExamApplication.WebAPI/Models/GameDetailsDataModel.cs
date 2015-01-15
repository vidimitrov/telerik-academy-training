namespace BullsAndCows.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using BullsAndCows.Models;

    public class GameDetailsDataModel
    {
        public GameDetailsDataModel(Game game)
        {
            this.Id = game.Id;
            this.Name = game.Name;
            this.Blue = game.BluePlayer.UserName;
            this.Red = game.RedPlayer.UserName;
            this.GameState = game.GameState;
            this.DateCreated = game.DateCreated;
            this.YourGuesses = new List<Guess>();
            this.OpponentGuesses = new List<Guess>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public string YourNumber { get; set; }

        public string YourColor { get; set; }

        public ICollection<Guess> YourGuesses { get; set; }

        public ICollection<Guess> OpponentGuesses { get; set; }
    }
}