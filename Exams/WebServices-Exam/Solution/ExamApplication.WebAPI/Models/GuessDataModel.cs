using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCows.WebAPI.Models
{
    public class GuessDataModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int GameId { get; set; }

        public string Number { get; set; }

        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}