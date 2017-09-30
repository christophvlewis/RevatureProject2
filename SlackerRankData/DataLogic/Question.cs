using System.Collections.Generic;
using System.Linq;
using SlackerRankData.Model;
using Microsoft.AspNetCore.Mvc;

namespace SlackerRankData.DataLogic
{
    [Produces("application/json")]
    public class Question
    {
        private ChallengerDBEntities context = new ChallengerDBEntities();

        // READ - Get list of Challenge Questions
        public List<Challenge> ListOfChallenges()
        {
            List<Challenge> ChallengeList = context.Challenges.ToList<Challenge>();
            return ChallengeList;
        } // End ListOfChallenges

        public Challenge

    } // End Question Class
} // End Namespace
