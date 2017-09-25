
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//tester takes teacher's code in the form of a string, teachers .exe path, and student's code and .exe path
//It has a "inputs" property and an "outputs" property, both iterable lists. 
namespace SlackerRankCompilerClasses
{
    public class Tester : SlackerCompile {
        //constructor for Tester
        string teachersCode;
        string teachersExe;
        string teachersPath;
        string studentsCode;
        string studentsExe;
        string studentsPath;
        public List<string> allInputs { set; get; }
        public List<string> myInputs { set; get; }
        public List<string> myOutputs { set; get; }

        

        public Tester(string teachersPath, string teachersExe, string teachersCode, string studentsPath, string studentsExe, string studentsCode, List<string> allInputs)
        {

            this.teachersCode = teachersCode;
            this.teachersPath = teachersPath;
            this.teachersExe = teachersExe;
            this.studentsCode = studentsCode;
            this.studentsExe = studentsExe;
            this.studentsPath = studentsPath;
            this.allInputs = allInputs;



        }
        //ensure no null issues.
        public bool TestIt() {

            SlackerCompile myTeacher = new SlackerCompile();
            SlackerCompile myStudent = new SlackerCompile();

            myTeacher.CompileIt(teachersPath, teachersExe, teachersCode);
            myStudent.CompileIt(studentsPath, studentsExe, studentsCode);
            Exception ex = new Exception();
            
            if (myStudent.CompileItResult != null) { throw ex; }

            List<string> myTeacherResult = myTeacher.RunIt(teachersPath, "");
            List<string> myStudentResult = myStudent.RunIt(studentsPath, "");

            if (myStudentResult[0] == myTeacherResult[0]) return true;

           


            return false;
        }



             /*

        public bool TestIt() {




        }


        public void SetInputs() {
           //sets myInputs List
             

        }

        RunTeacher() { }
        RunStudent() { }
        */
    }
}
