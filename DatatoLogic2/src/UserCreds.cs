using System;
using System.Collections.Generic;

namespace DatatoLogic2.src
{
    public partial class UserCreds
    {
        public string Email { get; set; }
        public string Psswrd { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Administrator Administrator { get; set; }
        public NonAdmin NonAdmin { get; set; }
    }
}
