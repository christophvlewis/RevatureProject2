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
	[Route("api/NonAdmins")]
    public class NonAdminsController : Controller
    {
        // GET api/NonAdmins
        [HttpGet]
        public IEnumerable<NonAdmin> Get()
        {
			return new List<NonAdmin>()
			{
				new NonAdmin(){   },
				new NonAdmin(){   },
				new NonAdmin(){   }
			};
        }

        // GET api/NonAdmins/{email}
        [HttpGet("{email}")]
        public NonAdmin Get(string email)
        {
			return new NonAdmin() { _email = email };
        }

        // POST api/NonAdmins
        [HttpPost]
        public NonAdmin Post([FromBody]NonAdmin NonAdmin)
        {
			if (!ModelState.IsValid || NonAdmin == null)
				return null;

			//add Administrator to Database

			return NonAdmin;
        }

        // PUT api/NonAdmins/{email}
        [HttpPut("{email}")]
        public void Put(string email, [FromBody]NonAdmin nonadmin_update)
        {
			//update NonAdmins with specific email from database
			if (!ModelState.IsValid || nonadmin_update == null)
				return;
        }

        // DELETE api/NonAdmins/{email}
        [HttpDelete("{email}")]
        public void Delete(string email)
        {
			//delete NonAdmins from database

        }
    }
}
