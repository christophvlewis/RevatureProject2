using System;
using System.Collections.Generic;

namespace DatatoLogic2.src
{
    public partial class Challenge
    {
        public Challenge()
        {
            Progress = new HashSet<Progress>();
        }

        public int QuestionNumber { get; set; }
        public string Objetive { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public ICollection<Progress> Progress { get; set; }
    }
}
