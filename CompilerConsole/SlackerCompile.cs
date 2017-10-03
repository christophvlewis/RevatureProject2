using System;
using System.IO;
using System.Globalization;
using System.Text;
using Microsoft.CSharp;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;


//TODO: ERROR CATCHING, try/catch blocks
//Pass text from input textbox to Program.CompileIt --> Using a viewModel to hold the input, pass Model object to Compiler
//Check if CompileIt suceeds. --> try catch, if fail return debug/error info back to the WebClient
//If Successfull, run program --> try catch, if fail return debug/error info back to the WebClient
//If program runs, return program output as a list of strings
//Pass this list of strings back to the WebClient, display this list of strings one after the other, on the WebClient --> using another ViewModel, pass to an IEnum object, than a foreach(item in Model) display will show results.

//Future Functionality:
//*****IDE PORTION*****//
//Line numbers in input box
//Appearance/Beautify --> Using CSS/Javascript/Some woo stack/etc. Make the display look like vsCode or similar popular compilers.
//Intellisense --> are their Intellisense libraries? If so, leverage these libraries, will likely need to asynchronously check input inside the input field

//*****CODE CHALLENGE PORTION*****//
//Way to add, remove, and store "code challenge"
//Page that describes code challenge
//let user give their own inputs
//test that code meets standard, i.e. "CHALLEGE COMPRETE"

//*****MISC*****//
//Login/user auth
//Keep track of completed code challenges, and perhaps save the code as well


//class SlackerRun : SlackerRankAPI.
namespace SlackerRankCompilerClasses
{
   public class SlackerCompile
    {
        public List<string> RunItResult { set; get; }
        public List<Diagnostic> CompileItResult { set; get; }
        public string MyCode { set; get; }
        public string MyPath { set; get; }
        public string MyExe { set; get; }
        public string MyArgs { set; get; }

        private static readonly IEnumerable<string> DefaultNamespaces =
            new[]
            {
                "System",
                "System.IO",
                "System.Net",
                "System.Linq",
                "System.Text",
                "System.Console",
                "System.Text.RegularExpressions",
                "System.Collections.Generic"
            };

        private static string runtimePath = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.1\{0}.dll";

        private static readonly IEnumerable<MetadataReference> DefaultReferences =
            new[]
            {
                MetadataReference.CreateFromFile(string.Format(runtimePath, "mscorlib")),
                MetadataReference.CreateFromFile(string.Format(runtimePath, "System")),
                MetadataReference.CreateFromFile(string.Format(runtimePath, "System.Core"))
            };

        private static readonly CSharpCompilationOptions DefaultCompilationOptions =
            new CSharpCompilationOptions(OutputKind.ConsoleApplication)
                    .WithOverflowChecks(true).WithOptimizationLevel(OptimizationLevel.Release);
                   // .WithUsings(DefaultNamespaces);

        public static SyntaxTree Parse(string text, string filename = "", CSharpParseOptions options = null)
        {
            if (text == null) text = "";
                var stringText = SourceText.From(text, Encoding.UTF8);
                return SyntaxFactory.ParseSyntaxTree(stringText, options);
            
        }

        public List<Diagnostic> CompileIt(string MyPath, string MyExe, string MyCode)
        {
            List<Diagnostic> CompileItResult = new List<Diagnostic>();
            //var fileToCompile = @"C:\Users\Chris\Desktop\C#\Program.cs";  // Directory for Program.cs (input code)
            //var source = File.ReadAllText(fileToCompile); // take string from input textbox, assign to this variable // where the file gets converted to string.

            
            
            var parsedSyntaxTree = Parse(MyCode, "", CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp5));

            var compilation
                = CSharpCompilation.Create(MyExe, new SyntaxTree[] { parsedSyntaxTree }, DefaultReferences, DefaultCompilationOptions);
            try
            {
                var result = compilation.Emit(MyPath);  //output file for code input 


                Console.WriteLine("Attempting to compile this code: " + MyCode);

                Console.WriteLine(result.Success ? "Success!!" : "Failed");
                //var myDiagnostics = result.Diagnostics.GetEnumerator;

                foreach (Diagnostic myResult in result.Diagnostics) Console.WriteLine(myResult);
                foreach (Diagnostic myResult in result.Diagnostics) CompileItResult.Add(myResult);
                return CompileItResult;
                //RETURN     --> need to run and show result of "test.exe"  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
                return CompileItResult;
            }


            //RETURN
            return CompileItResult;
        }

        public List<string> RunIt(string MyPath, string MyArguments) //Have method return an IEnumrable or list with the output strings, instead of writing directly to console.
        {


            //takes executable, runs executable, returns output from executable.
            List<string> myOutput = new List<string>(); //holds cmd line outputs as strings

            try
            {
                ProcessStartInfo pInfo = new ProcessStartInfo("cmd.exe");    //grabs cmd.exe, uses cmd.exe to run the .exe
                pInfo.FileName = MyPath;
                pInfo.WorkingDirectory = new FileInfo(MyPath).DirectoryName;
                pInfo.Arguments = MyArguments;
                pInfo.CreateNoWindow = false;

                pInfo.UseShellExecute = false;
                pInfo.WindowStyle = ProcessWindowStyle.Normal;
                pInfo.RedirectStandardOutput = true;
                Process p = Process.Start(pInfo);
                p.Start();
                while (!p.StandardOutput.EndOfStream)
                {
                    string line = p.StandardOutput.ReadLine();

                    myOutput.Add(line);
                    Console.WriteLine(line);      //Put into list or IEnumerable and pass this enum to the asp app.

                    // do something with line
                }
                //p.OutputDataReceived += p_OutputDataReceived;
                //p.BeginOutputReadLine();

                               

                p.WaitForExit();
                return myOutput;
            }
            catch(Exception ex)
            {
                throw ex;
                myOutput.Add(ex.ToString());
                return myOutput;
            }
            // set status based on return code.
            //if (p.ExitCode == 0) this.Status = StatusEnum.CompletedSuccess;
            //else this.Status = StatusEnum.CompletedFailure;

        }

        static void Main(string[] args)
        {
            /*       
         var fileToCompile = @"C:\Users\Chris\Desktop\C#\Program.cs";  // Directory for Program.cs (input code)
         var source = File.ReadAllText(fileToCompile); // take string from input textbox, assign to this variable // where the file gets converted to string.
         var parsedSyntaxTree = Parse(source, "", CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp5));

         var compilation
             = CSharpCompilation.Create("Test.exe", new SyntaxTree[] { parsedSyntaxTree }, DefaultReferences, DefaultCompilationOptions);
         try
         {
             var result = compilation.Emit(@"C:\Users\Chris\Desktop\C#\Test.exe");  //output file for code input 

             Console.WriteLine(result.Success ? "Success!!" : "Failed");
         }
         catch (Exception ex)
         {
             Console.WriteLine(ex);
         }
         Console.Read();   \
         */

           /*

            SlackerCompile myRunner = new SlackerCompile();
            myRunner.MyExe = "myGuy5.exe";
            myRunner.MyCode = "public class MyClass{ static void Main(string[] args){System.Console.WriteLine(\"Hello World\");  System.Console.WriteLine(\"testtesttest\"); }}";
            Console.WriteLine("Starting compilation");
            
            //myRunner.CompileItResult = myRunner.CompileIt();
            List<string> myOutput = myRunner.RunIt("C:\\" + myRunner.MyExe, "");//TODO: Have it use current working directory
            myRunner.RunItResult = myOutput;
              //Sets "myRunner" class instance property RunItResult to result of myRunner.RunIt return value.
           
           */
            //foreach (string line in myOutput) Console.WriteLine(line);   //DEBUG
            //Now a gotta build a gotdam api. --> Use interfaces. Make a "core" project, and then have the core project reference both the console proj and the webapp proj. Main exists in this core proj.
        }
    }
}