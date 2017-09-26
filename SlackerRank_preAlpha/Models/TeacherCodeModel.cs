using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlackerRank_preAlpha.Models
{
    public class TeacherCodeModel
    {
                          //model represents an individual code challenge.
        public int Id { set; get; }
        public string CodeIntro { set; get; }
        public string CodeSolution { set; get; }
        public string CodeExe { set; get; }
        public string CodePath { set; get; }
        //public List<string> CodeInputs { set; get; } --> implement model that creates a listing of codeinputs, and then map to this model.







    }
}
