namespace BullsAndCows.WebAPI.Controllers
{
    using BullsAndCows.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    
    [RoutePrefix("api/scores")]
    public class ScoresController : BaseApiController
    {
        public ScoresController(IGamesData data)
            : base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult All()
        {
            //1. Get all users as ScoreUsersDataModel
            //2. Sort the descending after calculate their rank with the formula
            //3. Return them

            return Ok();
        }
    }
}
