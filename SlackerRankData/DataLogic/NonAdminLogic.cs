using Microsoft.AspNetCore.Mvc;
using SlackerRankData.Model;
using System;
using System.Linq;

namespace SlackerRankData.DataLogic
{
    [Produces("application/json")]
    public class NonAdminLogic : UserCredLogic
    {
        private ChallengerDBEntities context = new ChallengerDBEntities();

        // CREATE a NonAdmin User
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

                NonAdmin userTemp = new NonAdmin();
                userTemp.Email = Email;
                context.NonAdmins.Add(userTemp);

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
                NonAdmin AdminTemp = context.NonAdmins.FirstOrDefault(i => i.Email == Email);
                context.NonAdmins.Remove(AdminTemp);

                UserCred Temp = context.UserCreds.FirstOrDefault(i => i.Email == Email);
                context.UserCreds.Remove(Temp);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        } // End DeleteUser

    } // End Class
} // End Namespace
