using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SlackerRankCompilerClasses;
using SlackerRank_preAlpha.Models;
using Microsoft.CodeAnalysis;
using SlackerRank_preAlpha.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;
using SlackerRank_preAlpha.Converters;

namespace SlackerRank_preAlpha.Controllers
{
    public class ProblemListController : Controller
    {
        private readonly MyDbContext _context;

        public ProblemListController(MyDbContext context)
        {
            _context = context;
        }

		/*
        public async Task<IActionResult> Index()
        {
			//Nicks Code
            return View(await _context.TeacherCode.ToListAsync());

        }*/

		public IActionResult Index()
		{
			return View(new TeacherCodeModel().GetListFromDatatabase());
		}


                   
        public IActionResult Solve(int id) {

            //grab teacher code, pass to the compilercontroller

            //  var teacherCode = await _context.TeacherCode
            //   .SingleOrDefaultAsync(t => t.Id == id); //grabs teacher row where id matches
            //  if (teacherCode == null) return NotFound();
            // TempData["myProblem"] = teacherCode;
            //return Content("test");
            return RedirectToAction("Index", "Compiler", new { id });
           // return RedirectToAction("Index","Compiler", new { id });





            return Content("HELLO WORLD" + id.ToString());



        }

        // controller for problem list, redirect to CompilerController
    }
}
