namespace BullsAndCows.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;
    
    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.WebAPI.Models;

    [RoutePrefix("api/games")]
    public class GamesController : BaseApiController
    {
        private const string NoBluePlayerMessage = "No blue player yet";

        public GamesController(IGamesData data)
            : base(data)
        {
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult Join(int id, GameCreationModel model)
        {
            var game = this.data.Games.Find(id);
            if (game == null)
            {
                return BadRequest("There is no game with this id!");
            }

            var currentUser = this.data.Users.Find(this.User.Identity.GetUserId());

            if (game.RedPlayer == currentUser)
            {
                return BadRequest("You cannot play with yourself!");
            }

            game.BluePlayer = currentUser;
            game.BluePlayerId = currentUser.Id;
            game.BluePlayerNumber = model.Number;
            

            //Choose random player for the first turn
            var firstPlayer = getRandomPlayerColor() == "red" 
                ? game.GameState = GameState.RedInTurn : game.GameState = GameState.BlueInTurn;


            this.data.Users.SaveChanges();

            return Ok(new { 
                result = String.Format("You joined game \'{0}\'", game.Name)
            });
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Details(int id)
        {
            var game = this.data.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            var currentUserId = this.User.Identity.GetUserId();

            if (game.BluePlayerId != currentUserId && game.RedPlayerId != currentUserId)
            {
                return BadRequest("You are not part of this game!");
            }

            var gameDetails = new GameDetailsDataModel(game);

            // fill the details with YourColor, YourNumber and both guesses

            return Ok(gameDetails);
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.All(0);
        }

        [HttpGet]
        public IHttpActionResult All(int page)
        {
            var currentUserIdentity = this.User.Identity;
            var currentUser = this.data.Users.Find(currentUserIdentity.GetUserId());

            var games = this.GetSortedGames()
                            .AsQueryable()
                            .Select(GameDataModel.FromGame);

            if (currentUserIdentity.IsAuthenticated)
            {
                games.Where(g => g.Blue == NoBluePlayerMessage && g.Blue == currentUser.UserName);
            }
            else
            {
                games.Where(g => g.Blue == NoBluePlayerMessage);
            }

            games.Skip(10 * page)
                 .Take(10)
                 .ToList();

            return Ok(games);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(GameCreationModel gameInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Incorrect game input!");
            }

            var currentUserIdentity = this.User.Identity;
            var currentUser = this.data.Users.Find(currentUserIdentity.GetUserId());

            var game = new Game(gameInput.Name);

            game.RedPlayer = currentUser;
            game.RedPlayerId = currentUser.Id;
            game.RedPlayerNumber = gameInput.Number;

            this.data.Games.Add(game);
            this.data.SaveChanges();

            return Ok(new GameDataModel { 
                Id = game.Id,
                Name = game.Name,
                Blue = game.BluePlayer != null ? game.BluePlayer.UserName : NoBluePlayerMessage,
                Red = game.RedPlayer.UserName,
                DateCreated = game.DateCreated,
                GameState = game.GameState
            });
        }
        
        private string getRandomPlayerColor()
        {
            var colors = new string[] {"red", "blue"};
            Random rnd = new Random();
            int randomNum = rnd.Next(0, 1);
            var randomColor = colors[randomNum];

            return randomColor;
        }

        private IQueryable<Game> GetSortedGames()
        {
            return this.data.Games.All()
                .OrderBy(g => g.GameState)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName);
        }
    }
}
