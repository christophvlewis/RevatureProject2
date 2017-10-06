using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataToLogicService.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Collections;

namespace DataToLogicService.Controllers
{
	[Produces("application/json")]
	[Route("api/Administrators")]
    public class AdministratorsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Administrator> Get()
        {
			return null;
				//new SlackerRankData.DataLogic.AdministratorLogic().ListOfAdministrators();
        }

        // GET api/Administrators/5
        [HttpGet("{email}")]
        public Administrator Get(string email)
        {
			return new Administrator() {  Email = "chris" + email.ToString() };
        }

        // POST api/Administrators
        [HttpPost]
        public Administrator Post([FromBody]Administrator Admin)
        {
			if (!ModelState.IsValid || Admin == null)
				return null;

			//add Administrator to Database

			return Admin;
        }

        // PUT api/Administrators/
        [HttpPut("{email}")]
        public Administrator Put(string email, [FromBody]Administrator admin_update)
        {
			//update Administrator from database
			return admin_update;
        }

		// DELETE api/Administrators/
		[HttpDelete("{email}")]
		public void Delete(string email)
        {
			//delete Administrator from database
        }
    }
}
