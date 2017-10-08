using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatatoLogic2.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Collections;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using DatatoLogic2.DataLogic;

namespace DataToLogic2.Controllers
{
	[Produces("application/json")]
	[Route("api/Administrators")]
    public class AdministratorsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Administrator> Get()
        {
			List<Administrator> return_admin_list = new List<Administrator>(); 
			AdministratorLogic a = new AdministratorLogic();
			foreach (var admin in a.ListOfAdministrators())
			{
				return_admin_list.Add(new Administrator()
				{ Email = admin.Email, FirstName = admin.FirstName, LastName = admin.LastName, Psswrd = admin.Psswrd });
			}
			return return_admin_list;
			
        }

        // GET api/Administrators/5
        [HttpGet("{email}")]
        public Administrator Get(string email)
        {
			// Code when connected : Get Single Administrator
			var get = new AdministratorLogic().GetAdmin(email);
			return new Administrator() { Email = get.Email, FirstName = get.FirstName, LastName = get.LastName, Psswrd = get.Psswrd };
        }

        // POST api/Administrators
        [HttpPost]
        public Administrator Post([FromBody]Administrator Admin)
        {
			if (!ModelState.IsValid || Admin == null)
				return null;

			// Code when connected : add Administrator to Database
			var add = new AdministratorLogic().CreateUser(Admin.Email, Admin.Psswrd, Admin.FirstName, Admin.LastName);

			return Admin;
        }

        // PUT api/Administrators/
        [HttpPut("{email}")]
        public Administrator Put(string email, [FromBody]Administrator admin_update)
        {
			if (!ModelState.IsValid || admin_update == null)
				return null;

			// Code when connected : update Administrator from database
			var update = new AdministratorLogic().UpdateUser(admin_update.Email, admin_update.Psswrd, admin_update.FirstName, admin_update.LastName);
			return admin_update;
        }

		// DELETE api/Administrators/
		[HttpDelete("{email}")]
		public void Delete(string email)
        {
			// Code when connected : delete Administrator from database
			var delete = new AdministratorLogic().DeleteUser(email);
        }

		[Route("testingstuff")]
		public int testingstuff()
		{
			return 1;
		}

    }
}
