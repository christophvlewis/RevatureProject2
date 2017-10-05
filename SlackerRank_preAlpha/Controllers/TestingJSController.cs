using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlackerRank_preAlpha.Controllers
{
    public class TestingJSController : Controller
    {

        public IActionResult index()
        {
            return View();
        }
    }
}
