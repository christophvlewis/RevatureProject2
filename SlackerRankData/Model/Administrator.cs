//------------------------------------------------------------------------------

//------------------------------------------------------------------------------

namespace SlackerRankData.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Administrator
    {
        public string Email { get; set; }
    
        public virtual UserCred UserCred { get; set; }
    }
}
