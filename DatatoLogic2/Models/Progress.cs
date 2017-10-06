using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatatoLogic2.Models
{
    public class Progress
    {
		public string Email { get; set; }
		public int NumberRight { get; set; }
		public int NumberWrong { get; set; }
		public int QuestionNumber { get; set; }
		public int TableId { get; set; }
	}
}
