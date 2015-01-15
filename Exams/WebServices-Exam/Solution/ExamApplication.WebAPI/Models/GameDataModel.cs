namespace BullsAndCows.WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;
    
    using BullsAndCows.Models;

    public class GameDataModel
    {
        private const string NoBluePlayerMessage = "No blue player yet";

        public static Expression<Func<Game, GameDataModel>> FromGame
        {
            get
            {
                return g => new GameDataModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Blue = g.BluePlayer != null ? g.BluePlayer.UserName : NoBluePlayerMessage,
                    Red = g.RedPlayer.UserName,
                    GameState = g.GameState, // Find how the use the string representation of the enum type
                    DateCreated = g.DateCreated
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}