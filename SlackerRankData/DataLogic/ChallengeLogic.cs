using System.Collections.Generic;
using System.Linq;
using SlackerRankData.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.Entity;

namespace SlackerRankData.DataLogic
{

	public class ChallengeLogic
    {
        private ChallengerDBEntities context = new ChallengerDBEntities();
        
        // CREATE a new Challenge
        public bool CreateChallenge(string Objective, string Question, string Answer)
        {
            try
            {
                Challenge temp = new Challenge();
                temp.Objetive = Objective; // Misspelling
                temp.Question = Question;
                temp.Answer = Answer;
                context.Challenges.Add(temp);

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
            List<Challenge> ChallengeList = context.Challenges.ToList<Challenge>();
            return ChallengeList;
        } // End ListOfChallenges

        // READ - Getting a single Challenge
        public Challenge GetChallenge(int Index)
        {
            Challenge temp = context.Challenges.FirstOrDefault(i => i.QuestionNumber == Index);
            return temp;
        } // End GetChallenge

        // UPDATE a Challenge Question
        public bool UpdateChallenge(int QuestionNumber, string Objective, string Question, string Answer)
        {
            try
            {
                Challenge temp = context.Challenges.FirstOrDefault(i => i.QuestionNumber == QuestionNumber);
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
                // Removing from Progress table
                List<Progress> AllRowsList = context.Progresses.ToList<Progress>();
                foreach (var row in AllRowsList)
                {
                    if (row.QuestionNumber == Index)
                    {
                        context.Progresses.Remove(row);
                    }
                }

                // Removing from Challenge questions table
                Challenge temp = context.Challenges.FirstOrDefault(i => i.QuestionNumber == Index);
                context.Challenges.Remove(temp);

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
