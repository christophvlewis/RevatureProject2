using System;
using System.Collections.Generic;

namespace DatatoLogic2.src
{
    public partial class Administrator
    {
        public string Email { get; set; }

        public UserCreds EmailNavigation { get; set; }
    }
}
