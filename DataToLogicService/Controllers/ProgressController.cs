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
	[Route("api/Progress")]
    public class ProgressController : Controller
    {
        // GET api/Progress
        [HttpGet]
        public IEnumerable<Progress> Get()
        {
			return new List<Progress>()
			{
				new Progress(){   },
				new Progress(){   },
				new Progress(){   }
			};
        }

        // GET api/Progress/{email}
        [HttpGet("{email}/{QN}")]
        public Progress Get(string email, int QN)
        {
			return new Progress() { };
        }

        // POST api/Progress
        [HttpPost]
        public Progress Post([FromBody]Progress pro)
        {
			if (!ModelState.IsValid || pro == null)
				return null;

			//add Administrator to Database

			return pro;
        }

        // PUT api/Progress/{email}
        [HttpPut("{email}")]
        public void Put(string email, [FromBody]NonAdmin nonadmin_update)
        {
			//update NonAdmins with specific email from database
			if (!ModelState.IsValid || nonadmin_update == null)
				return;
        }

        // DELETE api/Progress/{email}
        [HttpDelete("{email}")]
        public void Delete(string email)
        {
			//delete NonAdmins from database

        }
    }
}
