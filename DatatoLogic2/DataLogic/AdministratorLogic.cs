using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DatatoLogic2.src;

namespace DatatoLogic2.DataLogic
{
	public class AdministratorLogic : UserCredLogic
    {
		private ChallengerDBContext context = new ChallengerDBContext();


		// CREATE an Administrator
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

                Administrator AdminTemp = new Administrator();
                AdminTemp.Email = Email;
                context.Administrator.Add(AdminTemp);

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
        public UserCreds GetAdmin(string Email)
        {
            UserCreds temp = context.UserCreds.FirstOrDefault(i => i.Email == Email);
            return temp;
        } // End GetAdmin

        // READ - Get list of all Users
        public List<UserCreds> ListOfAdministrators()
        {
            List<UserCreds> NonAdminList = context.UserCreds.ToList<UserCreds>();
            return NonAdminList;
        } // End ListOfAdministrators

        // UPDATE an Administrator
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
                Administrator AdminTemp = context.Administrator.FirstOrDefault(i => i.Email == Email);
                context.Administrator.Remove(AdminTemp);

                UserCreds Temp = context.UserCreds.FirstOrDefault(i => i.Email == Email);
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

