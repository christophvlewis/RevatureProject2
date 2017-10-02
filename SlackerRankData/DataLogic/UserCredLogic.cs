using System.Linq;
using SlackerRankData.Model;
using Microsoft.AspNetCore.Mvc;

namespace SlackerRankData.DataLogic
{
    [Produces("application/json")]
    public abstract class UserCredLogic
    {
        private ChallengerDBEntities context = new ChallengerDBEntities();

        public abstract bool CreateUser(string Email, string Password, string FirstName, string LastName);

        public abstract bool DeleteUser(string Email);

        // READ - Getting selected Challenge
        public Challenge GetChallenge(int Index)
        {
            Challenge temp = context.Challenges.FirstOrDefault(i => i.QuestionNumber == Index);
            return temp;
        } // End GetChallenge

    } // End Class
} // End Namespace
