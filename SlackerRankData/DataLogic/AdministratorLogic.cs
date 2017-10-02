using Microsoft.AspNetCore.Mvc;
using SlackerRankData.Model;
using System.Data.Entity;
using System.Linq;
using System;

namespace SlackerRankData.DataLogic
{
    [Produces("application/json")]
    public class AdministratorLogic : UserCredLogic
    {
        private ChallengerDBEntities context = new ChallengerDBEntities();

        // CREATE an Administrator
        public override bool CreateUser(string Email, string Password, string FirstName, string LastName)
        {
            try
            {
                UserCred temp = new UserCred();
                temp.Email = Email;
                temp.Psswrd = Password;
                temp.FirstName = FirstName;
                temp.LastName = LastName;
                context.UserCreds.Add(temp);

                Administrator AdminTemp = new Administrator();
                AdminTemp.Email = Email;
                context.Administrators.Add(AdminTemp);

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }

        } // End CreateUser

        // DELETE a User
        public override bool DeleteUser(string Email)
        {
            try
            {
                Administrator AdminTemp = context.Administrators.FirstOrDefault(i => i.Email == Email);
                context.Administrators.Remove(AdminTemp);

                UserCred Temp = context.UserCreds.FirstOrDefault(i => i.Email == Email);
                context.UserCreds.Remove(Temp);
                context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        } // End DeleteUser

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
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        } // End CreateChallenge

        // UPDATE a Challenge Question
        public bool UpdateChallenge(int Index, string Objective, string Question, string Answer)
        {
            try
            {
                Challenge temp = context.Challenges.FirstOrDefault(i => i.QuestionNumber == Index);
                temp.Objetive = Objective;
                temp.Question = Question;
                temp.Answer = Answer;
                context.Entry(temp).State = EntityState.Modified; // Updating the selected Row

                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
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
                Challenge temp = context.Challenges.FirstOrDefault(i => i.QuestionNumber == Index);
                context.Challenges.Remove(temp);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        } // End DeleteChallenge

    } // End Class
} // End Namespace

