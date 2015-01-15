namespace BullsAndCows.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    
    using BullsAndCows.Data;

    public class BaseApiController : ApiController
    {
        protected IGamesData data;

        public BaseApiController(IGamesData data)
        {
            this.data = data;
        }
    }
}
