using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SlackerRank_preAlpha.Models;

namespace SlackerRank_preAlpha.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            /*

     public int Id { set; get; }
     public string CodeIntro { set; get; }
     public string CodeSolution { set; get; }
     public string CodeExe { set; get; }
     public string CodePath { set; get; }

 */
            //public List<string> CodeInputs { se
            if (context.TeacherCode.Any())
            {
                return;   // DB has been seeded
            }

            var teacherCodes = new TeacherCodeModel[]
            {
                new TeacherCodeModel { CodeIntro= "Test Code Intro!!!!",   CodeSolution= "Alexander",
                    CodeExe = "Teacher1.exe", CodePath = "C:/" },

            };

            foreach (TeacherCodeModel t in teacherCodes)
            {
                context.TeacherCode.Add(t);
            }
            context.SaveChanges();

        }    
    }
}