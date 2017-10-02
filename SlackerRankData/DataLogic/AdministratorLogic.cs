using Microsoft.AspNetCore.Mvc;
using SlackerRankData.Model;
using System.Data.Entity;
using System.Linq;
using System;
using System.Collections.Generic;

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

        // READ - Get a single Administrator
        public UserCred GetAdmin(string Email)
        {
            UserCred temp = context.UserCreds.FirstOrDefault(i => i.Email == Email);
            return temp;
        } // End GetAdmin

        // READ - Get list of all Users
        public List<UserCred> ListOfAdministrators()
        {
            List<UserCred> NonAdminList = context.UserCreds.ToList<UserCred>();
            return NonAdminList;
        } // End ListOfAdministrators

        // UPDATE an Administrator
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

    } // End Class
} // End Namespace

