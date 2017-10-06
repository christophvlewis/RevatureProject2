using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatatoLogic2.src;

namespace DatatoLogic2.DataLogic
{
    
    public class ProgressLogic
    {
		private ChallengerDBContext context = new ChallengerDBContext();

		// CREATE - Adding status of user attempts
		public bool AddStatus(string Email, int Correct, int Wrong, int QuestionNumber)
        {
            try
            {
                Progress Temp = new Progress();
                Temp.Email = Email;
                Temp.NumberRight = Correct;
                Temp.NumberWrong = Wrong;
                Temp.QuestionNumber = QuestionNumber;
                context.Progress.Add(Temp);

                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        } // End AddStatus

        // READ - Get status of user attempts
        public List<Progress> FindStatus(string Email, int QuestionNumber)
        { 
            var AllRows = context.Progress;
            var TempList = new List<Progress>();
            foreach (var p in AllRows)
            {
                if (p.Email == Email && p.QuestionNumber == QuestionNumber)
                    TempList.Add(new Progress
                    {
                        Email = p.Email,
                        QuestionNumber = p.QuestionNumber,
                        NumberRight = p.NumberRight,
                        NumberWrong = p.NumberWrong
                    });
            } // End foreach
            return TempList;
        } // End FindStatus

        // DELETE a user's progress record
        public bool DeleteStatus(string Email)
        {
            try
            {
                List<Progress> AllRowsList = context.Progress.ToList<Progress>();
                foreach (var row in AllRowsList)
                {
                    if (row.Email == Email)
                    {
                        context.Progress.Remove(row);
                    }
                }
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        } // End DeleteStatus

    } // End Class
} // End Namespace
