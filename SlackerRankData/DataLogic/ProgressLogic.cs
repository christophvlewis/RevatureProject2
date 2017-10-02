using Microsoft.AspNetCore.Mvc;
using SlackerRankData.Model;
using System.Collections.Generic;
using System;

namespace SlackerRankData.DataLogic
{
    [Produces("application/json")]
    public class ProgressLogic
    {
        private ChallengerDBEntities context = new ChallengerDBEntities();

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
                context.Progresses.Add(Temp);

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
            var AllRows = context.Progresses;
            var TempList = new List<Progress>();
            foreach(var p in AllRows)
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

    } // End Class
} // End Namespace
