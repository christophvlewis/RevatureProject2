using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatatoLogic2.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using DatatoLogic2.DataLogic;

namespace DataToLogic2.Controllers
{
	[Produces("application/json")]
	[Route("api/NonAdmins")]
    public class NonAdminsController : Controller
    {
        // GET api/NonAdmins
        [HttpGet]
        public IEnumerable<NonAdmin> Get()
        {
			List<NonAdmin> return_admin_list = new List<NonAdmin>();
			NonAdminLogic a = new NonAdminLogic();
			foreach (var nonadmin in a.ListOfNonAdmins())
			{
				return_admin_list.Add(new NonAdmin()
				{ Email = nonadmin.Email, FirstName = nonadmin.FirstName, LastName = nonadmin.LastName, Psswrd = nonadmin.Psswrd });
			}
			return return_admin_list;
		}

        // GET api/NonAdmins/{email}
        [HttpGet("{email}")]
        public NonAdmin Get(string email)
        {
			var get = new NonAdminLogic().GetAdmin(email);
			return new NonAdmin() { Email = get.Email, FirstName = get.FirstName, LastName = get.LastName, Psswrd = get.Psswrd };
		}

        // POST api/NonAdmins
        [HttpPost]
        public NonAdmin Post([FromBody]NonAdmin NonAdmin)
        {
			if (!ModelState.IsValid || NonAdmin == null)
				return null;

			//add Administrator to Database
			var add = new NonAdminLogic().CreateUser(NonAdmin.Email, NonAdmin.Psswrd, NonAdmin.FirstName, NonAdmin.LastName);

			return NonAdmin;
        }

        // PUT api/NonAdmins/{email}
        [HttpPut("{email}")]
        public NonAdmin Put(string email, [FromBody]NonAdmin nonadmin_update)
        {
			//update NonAdmins with specific email from database
			if (!ModelState.IsValid || nonadmin_update == null)
				return null;

			var update = new NonAdminLogic().UpdateUser(nonadmin_update.Email, nonadmin_update.Psswrd, nonadmin_update.FirstName, nonadmin_update.LastName);
			return nonadmin_update;
		}

        // DELETE api/NonAdmins/{email}
        [HttpDelete("{email}")]
        public void Delete(string email)
        {
			//delete NonAdmins from database
			var delete = new NonAdminLogic().DeleteUser(email);
		}
    }
}
