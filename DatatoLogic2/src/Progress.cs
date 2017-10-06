using System;
using System.Collections.Generic;

namespace DatatoLogic2.src
{
    public partial class Progress
    {
        public string Email { get; set; }
        public int NumberRight { get; set; }
        public int NumberWrong { get; set; }
        public int QuestionNumber { get; set; }
        public int TableId { get; set; }

        public NonAdmin EmailNavigation { get; set; }
        public Challenge QuestionNumberNavigation { get; set; }
    }
}
