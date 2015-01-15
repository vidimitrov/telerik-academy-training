namespace BullsAndCows.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Linq;

    using BullsAndCows.Models;
    using Microsoft.AspNet.Identity;
    using BullsAndCows.Data;
    using BullsAndCows.WebAPI.Models;

    public class GuessesController : BaseApiController
    {
        public GuessesController(IGamesData data)
            : base(data)
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(int id, GuessDataModel guessModel)
        {
            var game = this.data.Games.Find(id);
            if (game == null)
            {
                return BadRequest("Game with this id does not exist!");
            }

            if (game.GameState == GameState.Finished)
            {
                return BadRequest("This game is finished!");
            }

            var guess = new Guess();

            var currentUser = this.data.Users.Find(this.User.Identity.GetUserId());

            if (game.BluePlayerId == currentUser.Id)
            {
                if (game.GameState != GameState.BlueInTurn)
                {
                    return BadRequest("It is not your turn!");
                }
                else
                {
                    if (guessModel.Number == game.RedPlayerNumber)
                    {
                        currentUser.Wins++;
                        game.GameState = GameState.Finished;
                    }
                    else
                    {
                        CalculateBullsAndCows();
                    }

                    guess.Game = game;
                    guess.GameId = game.Id;
                    guess.BullsCount = 0; // the returned value
                    guess.CowsCount = 0; // the returned value
                    guess.DateMade = DateTime.Now;
                    guess.Number = guessModel.Number;
                    guess.User = currentUser;
                    guess.UserId = currentUser.Id;
                    guess.Username = currentUser.UserName;
                }
            }
            else if (game.RedPlayerId == currentUser.Id) 
            {
                if (game.GameState != GameState.RedInTurn)
                {
                    return BadRequest("It is not your turn!");
                }
                else
                {
                    if (guessModel.Number == game.BluePlayerNumber)
                    {
                        currentUser.Wins++;
                        game.GameState = GameState.Finished;
                    }
                    else
                    {
                        CalculateBullsAndCows();
                    }

                    guess.Game = game;
                    guess.GameId = game.Id;
                    guess.BullsCount = 0; // the returned value
                    guess.CowsCount = 0; // the returned value
                    guess.DateMade = DateTime.Now;
                    guess.Number = guessModel.Number;
                    guess.User = currentUser;
                    guess.UserId = currentUser.Id;
                    guess.Username = currentUser.UserName;
                }
            }
            else
            {
                return BadRequest("This is not your game!");
            }

            this.data.Guesses.Add(guess);
            this.data.SaveChanges();

            return Ok(new GuessDataModel { 
                Id = guess.Id,
                UserName = guess.Username,
                Number = guess.Number,
                DateMade = guess.DateMade,
                GameId = guess.GameId,
                UserId = guess.UserId,
                BullsCount = guess.BullsCount,
                CowsCount = guess.CowsCount
            });
        }

        private void CalculateBullsAndCows()
        {
            // TODO: implement simple game logic that returns structure of bulls and cows count
        }
    }
}
