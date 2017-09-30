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
        public override void CreateUser(string Email, string Password, string FirstName, string LastName)
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
        } // End CreateUser

        // CREATE a new Challenge
        public void CreateChallenge(string Objective, string Question, string Answer)
        {
            Challenge temp = new Challenge();
            temp.Objetive = Objective;
            temp.Question = Question;
            temp.Answer = Answer;
            context.Challenges.Add(temp);

            context.SaveChanges();
        } // End CreateChallenge

        // UPDATE a Challenge Question
        public void UpdateChallenge(int Index, string Objective, string Question, string Answer)
        {
            Challenge temp = context.Challenges.FirstOrDefault(i => i.QuestionNumber == Index);
            temp.Objetive = Objective;
            temp.Question = Question;
            temp.Answer = Answer;
            context.Entry(temp).State = EntityState.Modified; // Updating the selected Row

            context.SaveChanges();
        } // End UpdateChallenge

        // DELETE a Challenge
        public void DeleteChallenge(int Index)
        {
            Challenge temp = context.Challenges.FirstOrDefault(i => i.QuestionNumber == Index);
            context.Challenges.Remove(temp);

            context.SaveChanges();
        } // End DeleteChallenge

    } // End Class
} // End Namespace

