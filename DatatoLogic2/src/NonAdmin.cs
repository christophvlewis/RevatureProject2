using System;
using System.Collections.Generic;

namespace DatatoLogic2.src
{
    public partial class NonAdmin
    {
        public NonAdmin()
        {
            Progress = new HashSet<Progress>();
        }

        public string Email { get; set; }

        public UserCreds EmailNavigation { get; set; }
        public ICollection<Progress> Progress { get; set; }
    }

}
