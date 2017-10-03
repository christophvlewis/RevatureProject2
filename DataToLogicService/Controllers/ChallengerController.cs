using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataToLogicService.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace DataToLogicService.Controllers
{
	[Produces("application/json")]
	[Route("api/Challenges")]
    public class ChallengesController : Controller
    {
        // GET api/Challenges
        [HttpGet]
        public IEnumerable<Challenge> Get()
        {
			return new List<Challenge>()
			{
				new Challenge(){   },
				new Challenge(){   },
				new Challenge(){   }
			};
        }

        // GET api/Challenges/{email}
        [HttpGet("{int QN}")]
        public Challenge Get(int QN)
        {
			return new Challenge() {  };
        }

        // POST api/NonAdmins
        [HttpPost]
        public Challenge Post([FromBody]Challenge change)
        {
			if (!ModelState.IsValid || change == null)
				return null;

			//add Administrator to Database

			return change;
        }

        // PUT api/NonAdmins/{email}
        [HttpPut("{QN}")]
        public void Put(int QN, [FromBody]Challenge challenge_update)
        {
			//update NonAdmins with specific email from database
			if (!ModelState.IsValid || challenge_update == null)
				return;
        }

        // DELETE api/NonAdmins/{email}
        [HttpDelete("{QN}")]
        public void Delete(int QN)
        {
			//delete NonAdmins from database
        }
    }
}
