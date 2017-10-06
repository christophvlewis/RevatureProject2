using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SlackerRank_preAlpha.Models;
using SlackerRank_preAlpha.Data;

namespace SlackerRank_preAlpha.Controllers
{
    public class MyRestAPI : Controller
    {
       

    private readonly MyDbContext _context;

    public MyRestAPI(MyDbContext context)
    {
        _context = context;
    }


		[Route("/api/default")]
        public ActionResult APIDefault() {

            return View();





        }

        [HttpGet("/api/default")]
        public ActionResult APIGet() {
            
            return Ok(_context.TeacherCode.ToList());
        }

        [HttpPost("/api/default")]
        public ActionResult APISet() {

            return View();

        }


       
    }
}
