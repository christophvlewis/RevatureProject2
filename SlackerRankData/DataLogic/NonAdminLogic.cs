using System.Collections.Generic;
using System.Linq;
using SlackerRankData.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.Entity;

namespace SlackerRankData.DataLogic
{
  
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

        // READ - Get a single NonAdmin
        public UserCred GetAdmin(string Email)
        {
            UserCred temp = context.UserCreds.FirstOrDefault(i => i.Email == Email);
            return temp;
        } // End GetNonAdmin

        // READ - Get list of all NonAdmins
        public List<UserCred> ListOfNonAdmins()
        {
            List<UserCred> NonAdminList =
               (List<UserCred>)from a in context.NonAdmins
                               join u in context.UserCreds on a.Email equals u.Email
                               select new
                               {
                                   Email = u.Email,
                                   FirstName = u.FirstName,
                                   LastName = u.LastName
                               };
            return NonAdminList;
        } // End ListOfNonAdmins

        // UPDATE a NonAdmin
        public bool UpdateUser(string Email, string Password, string FirstName, string LastName)
        {
            try
            {
                UserCred temp = context.UserCreds.FirstOrDefault(i => i.Email == Email);
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
