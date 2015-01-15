namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Game
    {
        public Game()
        {
        }

        public Game(string name)
        {
            this.Name = name;
            this.GameState = GameState.WaitingForOpponent;
            this.DateCreated = DateTime.Now;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string BluePlayerId { get; set; }

        public virtual ApplicationUser BluePlayer { get; set; }

        public string BluePlayerNumber { get; set; }

        public string RedPlayerId { get; set; }

        public virtual ApplicationUser RedPlayer { get; set; }

        public string RedPlayerNumber { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
