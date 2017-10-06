using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using DatatoLogic2.src;

namespace DatatoLogic2.DataLogic
{

	public class ChallengeLogic
    {
        private ChallengerDBContext context = new ChallengerDBContext();

		// CREATE a new Challenge
		public bool CreateChallenge(string Objective, string Question, string Answer)
        {
            try
            {
                Challenge temp = new Challenge();
                temp.Objetive = Objective; // Misspelling
                temp.Question = Question;
                temp.Answer = Answer;
                context.Challenge.Add(temp);

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        } // End CreateChallenge

        // READ - Get list of Challenge Questions
        public List<Challenge> ListOfChallenges()
        {
            List<Challenge> ChallengeList = context.Challenge.ToList<Challenge>();
            return ChallengeList;
        } // End ListOfChallenges

        // READ - Getting a single Challenge
        public Challenge GetChallenge(int Index)
        {
            Challenge temp = context.Challenge.FirstOrDefault(i => i.QuestionNumber == Index);
            return temp;
        } // End GetChallenge

        // UPDATE a Challenge Question
        public bool UpdateChallenge(int QuestionNumber, string Objective, string Question, string Answer)
        {
            try
            {
                Challenge temp = context.Challenge.FirstOrDefault(i => i.QuestionNumber == QuestionNumber);
                temp.Objetive = Objective;
                temp.Question = Question;
                temp.Answer = Answer;
                context.Entry(temp).State = EntityState.Modified; // Updating the selected Row

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }

        } // End UpdateChallenge

        // DELETE a Challenge
        public bool DeleteChallenge(int Index)
        {
            try
            {
                Challenge temp = context.Challenge.FirstOrDefault(i => i.QuestionNumber == Index);
                context.Challenge.Remove(temp);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        } // End DeleteChallenge
        
    } // End Question Class
} // End Namespace
