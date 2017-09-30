using System.Linq;
using SlackerRankData.Model;
using Microsoft.AspNetCore.Mvc;

namespace SlackerRankData.DataLogic
{
    [Produces("application/json")]
    public abstract class UserCredLogic
    {
        private ChallengerDBEntities context = new ChallengerDBEntities();

        public abstract void CreateUser(string Email, string Password, string FirstName, string LastName);

        // READ - Getting selected Challenge
        public Challenge GetChallenge(int Index)
        {
            Challenge temp = context.Challenges.FirstOrDefault(i => i.QuestionNumber == Index);
            return temp;
        } // End GetChallenge

    } // End Class
} // End Namespace
