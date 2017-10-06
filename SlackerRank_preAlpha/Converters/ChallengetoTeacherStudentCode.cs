using SlackerRank_preAlpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlackerRank_preAlpha.Converters
{
    public class ChallengetoTeacherStudentCode
    {
		public int QuestionNumber { get; set; }
		public string Objective { get; set; }
		public string Question { get; set; }
		public string Answer { get; set; }

		public TeacherCodeModel ToTeacherCodeModel(string exe, string path)
		{
			return new TeacherCodeModel()
			{
				Id = QuestionNumber,
				CodeIntro = Objective,
				CodeSolution = Answer,
				CodeExe = exe,
				CodePath = path
			};
		}

		public StudentCodeModel ToStudentCodeModel(string exe, string path)
		{
			return new StudentCodeModel()
			{
				Id = QuestionNumber,
				CodeSolution = Answer,
				CodeExe = exe,
				CodePath = path
			};
		}

		public void FromTeacherModel(TeacherCodeModel tc)
		{
			QuestionNumber = tc.Id;
			Objective = tc.CodeIntro;
			Answer = tc.CodeSolution;
			Question = "null";
		}

	}
}
