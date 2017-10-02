using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SlackerRankData.DataLogic;

namespace SlackerRankData.TestData
{
    public class Test
    {
        //// CREATE Administrator Test
        //[Fact]
        //public static void TestCreateUser()
        //{
        //    var Admin = new AdministratorLogic();
        //    string Email = "T800@gmail.com";
        //    string Password = "MustDestroy";
        //    string FirstName = "Aanold";
        //    string LastName = "Schvatzanega";
        //    var success = Admin.CreateUser(Email, Password, FirstName, LastName);
        //    Assert.True(success);
        //    Assert.False(Admin.CreateUser(Email, Password, FirstName, LastName));
        //} // End TestCreateUser

        // DELETE Administrator Test
        //[Fact]
        //public static void TestDeleteUser()
        //{
        //    var Admin = new AdministratorLogic();
        //    string Email = "Miah@gmail.com";
        //    var success = Admin.DeleteUser(Email);
        //    Assert.True(success);
        //    Assert.False(Admin.DeleteUser(Email));
        //} // End TestDeleteUser

        // CREATE NonAdmin Test
        //[Fact]
        //public static void TestCreateUser()
        //{
        //    var NonAdmin = new NonAdminLogic();
        //    string Email = "Colorado@gmail.com";
        //    string Password = "MountainLife";
        //    string FirstName = "Snowboard";
        //    string LastName = "Rider";
        //    var success = NonAdmin.CreateUser(Email, Password, FirstName, LastName);
        //    Assert.True(success);
        //    Assert.False(NonAdmin.CreateUser(Email, Password, FirstName, LastName));
        //} // End TestCreateUser

        // ******************************************************* CREATE Challenge Question
        //[Fact]
        //public static void TestCreateChallenge()
        //{
        //    var TempChallenge = new AdministratorLogic();
        //    string Objective = "Objective9";
        //    string Question = "Question9";
        //    string Answer = "Answer9";
        //    var success = TempChallenge.CreateChallenge(Objective, Question, Answer);
        //    Assert.True(success);
        //} // End TestCreateChallenge
        // *********************************************************

        // DELETE Challenge Question
        //[Fact]
        //public static void TestDeleteChallenge()
        //{
        //    var TempChallenge = new AdministratorLogic();
        //    int Index = 1;
        //    var success = TempChallenge.DeleteChallenge(Index);
        //    Assert.True(success);
        //} // End TestDeleteChallenge

        // UPDATE Challenge Question
        //[Fact]
        //public static void TestUpdateChallenge()
        //{
        //    var TempChallenge = new AdministratorLogic();
        //    int Index = 3;
        //    string Objective = "Objective5";
        //    string Question = "Question5";
        //    string Answer = "Answer5";
        //    var success = TempChallenge.UpdateChallenge(Index, Objective, Question, Answer);
        //    Assert.True(success);
        //} // End TestCreateChallenge

        // CREATE Status
        [Fact]
        public static void TestCreateStatus()
        {
            var TempProgress = new ProgressLogic();
            string Email = "Colorado@gmail.com";
            int Correct = 0;
            int Wrong = 1;
            int QuestionNumber = 2;
            var success = TempProgress.AddStatus(Email, Correct, Wrong, QuestionNumber);
            Assert.True(success);
        } // End TestCreateStatus


    } // End Test class
} // End Namespace