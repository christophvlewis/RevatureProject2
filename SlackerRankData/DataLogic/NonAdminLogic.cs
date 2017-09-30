using Microsoft.AspNetCore.Mvc;
using SlackerRankData.Model;

namespace SlackerRankData.DataLogic
{
    [Produces("application/json")]
    public class NonAdminLogic : UserCredLogic
    {
        private ChallengerDBEntities context = new ChallengerDBEntities();

        // CREATE a NonAdmin User
        public override void CreateUser(string Email, string Password, string FirstName, string LastName)
        {
            UserCred temp = new UserCred();
            temp.Email = Email;
            temp.Psswrd = Password;
            temp.FirstName = FirstName;
            temp.LastName = LastName;
            context.UserCreds.Add(temp);

            NonAdmin userTemp = new NonAdmin();
            userTemp.Email = Email;
            context.NonAdmins.Add(userTemp);

            context.SaveChanges();
        } // End CreateUser
    } // End Class
} // End Namespace
