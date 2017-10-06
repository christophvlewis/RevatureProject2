using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using DatatoLogic2.src;

namespace DatatoLogic2.DataLogic
{
  
    public class NonAdminLogic : UserCredLogic
    {
		private ChallengerDBContext context = new ChallengerDBContext();

        // CREATE a NonAdmin User
        public override bool CreateUser(string Email, string Password, string FirstName, string LastName)
        {
            try
            {
                UserCreds temp = new UserCreds();
                temp.Email = Email;
                temp.Psswrd = Password;
                temp.FirstName = FirstName;
                temp.LastName = LastName;
                context.UserCreds.Add(temp);

                NonAdmin userTemp = new NonAdmin();
                userTemp.Email = Email;
                context.NonAdmin.Add(userTemp);

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }

        } // End CreateUser

        // READ - Get a single NonAdmin
        public UserCreds GetAdmin(string Email)
        {
            UserCreds temp = context.UserCreds.FirstOrDefault(i => i.Email == Email);
            return temp;
        } // End GetNonAdmin

        // READ - Get list of all Users
        public List<UserCreds> ListOfNonAdmins()
        {
            List<UserCreds> NonAdminList = context.UserCreds.ToList<UserCreds>();
            return NonAdminList;
        } // End ListOfNonAdmins

        // UPDATE a NonAdmin
        public bool UpdateUser(string Email, string Password, string FirstName, string LastName)
        {
            try
            {
                UserCreds temp = context.UserCreds.FirstOrDefault(i => i.Email == Email);
                temp.Psswrd = Password;
                temp.FirstName = FirstName;
                temp.LastName = LastName;
                context.UserCreds.Add(temp);
                context.Entry(temp).State = EntityState.Modified; // Updating the selected Row

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }

        } // End UpdateUser

        // DELETE a User
        public override bool DeleteUser(string Email)
        {
            try
            {
                NonAdmin AdminTemp = context.NonAdmin.FirstOrDefault(i => i.Email == Email);
                context.NonAdmin.Remove(AdminTemp);

                UserCreds Temp = context.UserCreds.FirstOrDefault(i => i.Email == Email);
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
