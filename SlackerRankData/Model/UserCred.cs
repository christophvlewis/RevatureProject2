//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SlackerRankData.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserCred
    {
        public string Email { get; set; }
        public string Psswrd { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public virtual Administrator Administrator { get; set; }
        public virtual NonAdmin NonAdmin { get; set; }
        public virtual Progress Progress { get; set; }

        public static implicit operator UserCred(NonAdmin v)
        {
            throw new NotImplementedException();
        }
    }
}
