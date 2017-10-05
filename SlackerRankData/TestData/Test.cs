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

        // *******************************Administrator**********************************
        // CREATE Administrator Test
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

        // UPDATE Administrator Test
        //[Fact]
        //public static void TestUpdateUser()
        //{
        //	var Admin = new AdministratorLogic();
        //	string Email = "BadAss@gmail.com";
        //	string Password = "TotallyBadAss";
        //	string FirstName = "Mack";
        //	string LastName = "McElhenney";
        //	var success = Admin.UpdateUser(Email, Password, FirstName, LastName);
        //	Assert.True(success);
        //} // End TestUpdateUser

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
        // *******************************Administrator**********************************

        // *******************************NonAdmin**********************************
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

        // UPDATE NonAdmin Test
        //[Fact]
        //public static void TestUpdateUser()
        //{
        //    var NonAdmin = new NonAdminLogic();
        //    string Email = "Failure@gmail.com";
        //    string Password = "NotAWinner";
        //    string FirstName = "Rotten";
        //    string LastName = "Clinton";
        //    var success = NonAdmin.UpdateUser(Email, Password, FirstName, LastName);
        //    Assert.True(success);
        //} // End TestUpdateUser

        // DELETE NonAdmin Test
        //[Fact]
        //public static void TestDeleteUser()
        //{
        //    var NonAdmin = new NonAdminLogic();
        //    string Email = "Success@gmail.com";
        //    var success = NonAdmin.DeleteUser(Email);
        //    Assert.True(success);
        //    Assert.False(NonAdmin.DeleteUser(Email));
        //} // End TestDeleteUser
        // *******************************NonAdmin**********************************

        // *******************************Challenge Questions**********************************
        // CREATE Challenge Question
        //[Fact]
        //public static void TestCreateChallenge()
        //{
        //    var TempChallenge = new ChallengeLogic();
        //    string Objective = "Objective9";
        //    string Question = "Question9";
        //    string Answer = "Answer9";
        //    var success = TempChallenge.CreateChallenge(Objective, Question, Answer);
        //    Assert.True(success);
        //} // End TestCreateChallenge

        // UPDATE Challenge Question
        //[Fact]
        //public static void TestUpdateChallenge()
        //{
        //    var TempChallenge = new ChallengeLogic();
        //    int Index = 3;
        //    string Objective = "Objective5";
        //    string Question = "Question5";
        //    string Answer = "Answer5";
        //    var success = TempChallenge.UpdateChallenge(Index, Objective, Question, Answer);
        //    Assert.True(success);
        //} // End TestCreateChallenge

        // DELETE Challenge Question
        //[Fact]
        //public static void TestDeleteChallenge()
        //{
        //    var TempChallenge = new ChallengeLogic();
        //    int Index = 3;
        //    var success = TempChallenge.DeleteChallenge(Index);
        //    Assert.True(success);
        //} // End TestDeleteChallenge
          // *******************************Challenge Questions**********************************

        // *******************************Progress**********************************
        // CREATE Status
        //[Fact]
        //public static void TestCreateStatus()
        //{
        //    var TempProgress = new ProgressLogic();
        //    string Email = "Hawaii@gmail.com";
        //    int Correct = 1;
        //    int Wrong = 0;
        //    int QuestionNumber = 4;
        //    var success = TempProgress.AddStatus(Email, Correct, Wrong, QuestionNumber);
        //    Assert.True(success);
        //} // End TestCreateStatus

        // DELETE Progress Test
        //[Fact]
        //public static void TestDeleteProgress()
        //{
        //    var Status = new ProgressLogic();
        //    string Email = "Hawaii@gmail.com";
        //    var success = Status.DeleteStatus(Email);
        //    Assert.True(success);
        //} // End TestDeleteUser
        // *******************************Progress**********************************

    } // End Test class
} // End Namespace