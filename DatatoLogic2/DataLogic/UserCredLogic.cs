using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatatoLogic2.src;

namespace DatatoLogic2.DataLogic
{
    
    public abstract class UserCredLogic
    {
        private ChallengerDBContext context = new ChallengerDBContext();

		public abstract bool CreateUser(string Email, string Password, string FirstName, string LastName);

        public abstract bool DeleteUser(string Email);


    } // End Class
} // End Namespace
