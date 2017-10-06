using System.Linq;
using SlackerRankData.Model;
using Microsoft.AspNetCore.Mvc;

namespace SlackerRankData.DataLogic
{
    
    public abstract class UserCredLogic
    {
        private ChallengerDBEntities context = new ChallengerDBEntities();

        public abstract bool CreateUser(string Email, string Password, string FirstName, string LastName);

        public abstract bool DeleteUser(string Email);


    } // End Class
} // End Namespace
