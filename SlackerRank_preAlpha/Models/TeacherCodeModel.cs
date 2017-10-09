using Newtonsoft.Json;
using SlackerRank_preAlpha.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

		string serverhttp = "http://ec2-54-174-148-114.compute-1.amazonaws.com/DatatoLogic2/";

		public TeacherCodeModel GetFromDatabase(int id)
		{
			var teachcode = new TeacherCodeModel();
			var client = new HttpClient();
			//var res = client.GetAsync("http://localhost:63040/api/Challenges/" + id).GetAwaiter().GetResult();
			//var res = client.GetAsync("http://localhost/DatatoLogic2/api/Challenges/" + id).GetAwaiter().GetResult();

			var res = client.GetAsync(serverhttp + "api/Challenges/"+ id).GetAwaiter().GetResult();


			if (res.IsSuccessStatusCode)
			{
				var r = res.Content.ReadAsStringAsync().Result;
				var p = JsonConvert.DeserializeObject<ChallengetoTeacherStudentCode>(r);
				teachcode = p.ToTeacherCodeModel("myTeacher.exe", @"C:\Users\Chris\Desktop\myTeacher.exe");
			}
			else
				return null;

			return teachcode;
		}

		public List<TeacherCodeModel> GetListFromDatatabase()
		{
			var list = new List<TeacherCodeModel>();
			var client = new HttpClient();
			//var res = client.GetAsync("http://localhost:63040/api/Challenges").GetAwaiter().GetResult();
			//var res = client.GetAsync("http://localhost:DatatoLogic2/api/Challenges").GetAwaiter().GetResult();

			//var res = client.GetAsync(serverhttp + "api/Challenges").GetAwaiter().GetResult();


			if (res.IsSuccessStatusCode)
			{
				var r = res.Content.ReadAsStringAsync().Result;
				var p = JsonConvert.DeserializeObject<List<ChallengetoTeacherStudentCode>>(r);

				foreach (var teach in p)
				{
					list.Add(teach.ToTeacherCodeModel("exestuff", "pathstuff"));
				}
			}
			return list;
		}

		public void AddtoDatabase(TeacherCodeModel tc)
		{
			var client = new HttpClient();
			var c = new ChallengetoTeacherStudentCode();
			c.FromTeacherModel(tc);

			var r = JsonConvert.SerializeObject(c);

			var stringstuff = new StringContent(r, Encoding.UTF8, "application/json");

			var res = client.PostAsync("http://localhost:63040/api/Challenges", stringstuff).GetAwaiter().GetResult();
		}

		public void DeletefromDatabase(int id)
		{
			var client = new HttpClient();

			var res = client.DeleteAsync("http://localhost:63040/api/Challenges/" + id).GetAwaiter().GetResult();
		}

		public TeacherCodeModel UpdatetoDatabase(TeacherCodeModel tc)
		{
			var client = new HttpClient();

			var convert = new ChallengetoTeacherStudentCode();
			convert.FromTeacherModel(tc);

			var r = JsonConvert.SerializeObject(tc);

			var stringstuff = new StringContent(r, Encoding.UTF8, "application/json");

			var res = client.PutAsync("http://localhost:63040/api/Challenges/" + convert.QuestionNumber, stringstuff).GetAwaiter().GetResult();


			var ri = res.Content.ReadAsStringAsync().Result;
			var p = JsonConvert.DeserializeObject<ChallengetoTeacherStudentCode>(ri);

			return p.ToTeacherCodeModel("exestuff", "pathstuff");
		}
		



    }
}
