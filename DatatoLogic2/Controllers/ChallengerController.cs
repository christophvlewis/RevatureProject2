using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatatoLogic2.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using DatatoLogic2.DataLogic; 

namespace DataToLogic2.Controllers
{
	[Produces("application/json")]
	[Route("api/Challenges")]
    public class ChallengesController : Controller
    {
        // GET api/Challenges
        [HttpGet]
        public IEnumerable<Challenge> Get()
        {
			// Code when connected : get all challenges
			var list_of_challenges = new ChallengeLogic().ListOfChallenges();
			List<Challenge> ch = new List<Challenge>();
			foreach (var item in list_of_challenges)
			{
				ch.Add(new Challenge() { QuestionNumber = item.QuestionNumber, Answer = item.Answer, Objective = item.Objetive, Question = item.Question });
			}

			return ch;
        }

        // GET api/Challenges/{email}
        [HttpGet("{QN}")]
        public Challenge Get(int QN)
        {
			var get = new ChallengeLogic().GetChallenge(QN);
			return new Challenge() { QuestionNumber = get.QuestionNumber, Answer = get.Answer, Objective = get.Objetive, Question = get.Question };
        }

        // POST api/Challenges
        [HttpPost]
        public Challenge Post([FromBody]Challenge change)
        {
			if (!ModelState.IsValid || change == null)
				return null;

			//add Administrator to Database
			var add = new ChallengeLogic().CreateChallenge(change.Objective, change.Question, change.Answer); 
			return change;
        }

        // PUT api/Challenges/{QN}
        [HttpPut("{QN}")]
        public void Put(int QN, [FromBody]Challenge challenge_update)
        {
			//update NonAdmins with specific email from database
			if (!ModelState.IsValid || challenge_update == null)
				return;

			var update = new ChallengeLogic().UpdateChallenge(QN, challenge_update.Objective, challenge_update.Question, challenge_update.Answer);
        }

        // DELETE api/Challenges/{QN}
		// Doesnt work yet, there is probably a dependancy somewhere, progress?
        [HttpDelete("{QN}")]
        public void Delete(int QN)
        {
			//delete NonAdmins from database
			var delete = new ChallengeLogic().DeleteChallenge(QN);
        }
    }
}
