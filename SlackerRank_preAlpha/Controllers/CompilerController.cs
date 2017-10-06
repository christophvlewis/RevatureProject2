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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SlackerRank_preAlpha.Controllers
{
    public class CompilerController : Controller
    {

        private readonly MyDbContext _context;

        public CompilerController(MyDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index(int? id)
        {
           // return View();
            //return Content("hello" + id.ToString());
             

            TempData["myProblem"] = id;
          

            return View();
        }
        [HttpPost]
        public IActionResult Index(CompilerModel model)
        {
            /*
          SlackerCompile testRunner = new SlackerCompile();
          testRunner.MyExe = @"C:\myTeacher.exe";
          testRunner.MyCode = "using System;public class Program{static void Main(){int myInput = 1000;int mySum = 0;for (int i = myInput - 1; i > 0; i--) { if (i % 3 == 0 || i % 5 == 0) mySum = mySum + i; }Console.WriteLine(mySum);";
          testRunner.MyArgs = "";
          testRunner.CompileItResult = testRunner.CompileIt(testRunner.MyCode, testRunner.MyExe);
          testRunner.RunItResult = testRunner.RunIt(testRunner.MyExe,testRunner.MyArgs);
           */
            //If we list all the natural numbers below 10 that are multiples of 3 or 5, 
            //we get 3, 5, 6 and 9.The sum of these multiples is 23.
            //Find the sum of all the multiples of 3 or 5 below 1000.

            var myId = TempData["myProblem"];
            int toIntId;
            int.TryParse(myId.ToString(), out toIntId);

			var teachcode = new TeacherCodeModel().GetFromDatabase(toIntId);


			/*
			var myTeacherCode = _context.TeacherCode
             .SingleOrDefault(t => t.Id == toIntId); //grabs teacher row where id matches
            if (myTeacherCode == null) return Content("BLEEEECH");
			*/

            //TeacherCodeModel myTeacherCode = (TeacherCodeModel)TempData["myProblem"];
            
            
            List<string> testList = new List<string> {"1","2" };
            string testStudentCode = "using System;public class Program { static void Main() { int myInput = 1000; int mySum = 0; for (int i = myInput - 1; i > 0; i--) { if (i % 3 == 0 || i % 5 == 0) mySum = mySum + i; } Console.WriteLine(mySum); } }";
            string testTeacherCode = "using System;public class sum{public static void Main(){int sum = 0;for (int i = 1; i <= 999; i++){if (i % 3 == 0 || i % 5 == 0) { sum += i; }}Console.WriteLine(sum);}}";
			//Tester myTester = new Tester(@"C:\myTeacher.exe", "myTeacher.exe",testTeacherCode, @"C:\myStudent.exe", "myStudent.exe",testStudentCode, testList);
			//Tester myTester = new Tester(myTeacherCode.CodePath + myTeacherCode.CodeExe, myTeacherCode.CodeExe, myTeacherCode.CodeSolution, @"C:\myStudent.exe", "myStudent.exe", model.inputCode, testList);
			Tester myTester = new Tester(teachcode.CodePath + teachcode.CodeExe, teachcode.CodeExe, teachcode.CodeSolution, @"C:\Users\Chris\Desktop\myStudent.exe", "myStudent.exe", model.inputCode, testList);


			// return Content(model.inputCode);
			//return Content(myTeacherCode.CodeSolution);
			bool myTestResult = myTester.TestIt();
            return Content(myTestResult.ToString());

            //sending inputs into the prog.
            //testRunner.CompileIt
            //testRunner.RunIt

            //take try catch code here, put in compiler class.
            SlackerCompile myRunner = new SlackerCompile();
            myRunner.MyExe = "myGuy.exe";
            myRunner.MyPath = @"C:\"+myRunner.MyExe;
            string test = myRunner.MyExe;
            // myRunner.MyCode = "public class MyClass{ static void Main(string[] args){System.Console.WriteLine("Hello World");  System.Console.WriteLine("testtesttest"); }}";
            myRunner.MyCode = model.inputCode;
            Console.WriteLine("Starting compilation");

            myRunner.CompileItResult = myRunner.CompileIt(myRunner.MyPath, myRunner.MyExe, myRunner.MyCode);
          

            List<Diagnostic> myResult = myRunner.CompileItResult;

            try
            {

                List<string> myOutput = myRunner.RunIt(myRunner.MyPath, "");//TODO: Have it use current working directory


                myRunner.RunItResult = myOutput;

                string StringOutput = "";

                foreach (string myString in myOutput) StringOutput += myString;
                model.outputCode = StringOutput;
                var myModel = model;
               return View(myModel);
                return Content(StringOutput);
            }

            catch {

                string StringResult = "";
                foreach (Diagnostic diagnostic in myResult)
                {
                    StringResult += diagnostic.ToString();

                }

                model.outputCode = StringResult;
                var myModel = model;
                return View(myModel);
                return Content(StringResult);

            }

            

           

            
            
            //myRunner.MyCode = "public class MyClass{ static void Main(string[] args){System.Console.WriteLine(\"Hello World\"); System.Console.ReadLine(); System.Console.WriteLine(\"testtesttest\"); }}";
            

            

                    //TODO: Have it use current working directory
          

            
            return View();

        }
    }
}
