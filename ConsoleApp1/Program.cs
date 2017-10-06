using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
			//Administrator stuff is good
			//GetAdmininstrator();
			//PostAdministrator();
			//PutAdministrator();
			//DeleteAdministrator();

			//Challenge stuff
			//PostChallenges();
			//PutChallenges();
			//DeleteChallenges();


		}

		public static void GetAdmininstrator()
		{
			var client = new HttpClient();

			var res = client.GetAsync("http://localhost:63040/api/Administrators").GetAwaiter().GetResult();

			if (res.IsSuccessStatusCode)
			{
				var r = res.Content.ReadAsStringAsync().Result;
				var p = JsonConvert.DeserializeObject<List<Stuff>>(r);

				foreach (var item in p)
				{
					Console.WriteLine(item);
					Console.WriteLine("FirstName: " + item.FirstName);
					Console.WriteLine("LastName: " + item.LastName);
					Console.WriteLine("Email: " + item.Email);
					Console.WriteLine("Password: " + item.Psswrd);

				}
			}
			else
			{
				Console.WriteLine("error");
			}

			Console.ReadLine();
		}

		public static void PostAdministrator()
		{
			var client = new HttpClient();

			var r = JsonConvert.SerializeObject(new Stuff() { Email = "jim" });

			var stringstuff = new StringContent(r, Encoding.UTF8, "application/json");

			var res = client.PostAsync("http://localhost:63040/api/Administrators",stringstuff).GetAwaiter().GetResult();


			var ri = res.Content.ReadAsStringAsync().Result;
			var p = JsonConvert.DeserializeObject<Stuff>(ri);

			Console.WriteLine(p.Email);
			
			Console.ReadLine();

		}


		public static void PutAdministrator()
		{
			var client = new HttpClient();

			var r = JsonConvert.SerializeObject(new Stuff() { Email = "Email@gmail.com", FirstName = "FirstNameAgain", LastName = "LastNameAgain", Psswrd = "password2" });

			var stringstuff = new StringContent(r, Encoding.UTF8, "application/json");

			var res = client.PutAsync("http://localhost:63040/api/Administrators/Email@gmail.com", stringstuff).GetAwaiter().GetResult();


			var ri = res.Content.ReadAsStringAsync().Result;
			var p = JsonConvert.DeserializeObject<Stuff>(ri);

			Console.WriteLine(p.Email);

			Console.ReadLine();

		}

		// need to fix
		public static void DeleteAdministrator()
		{
			var client = new HttpClient();

			Console.WriteLine("Write the Email you want to delete");
			var deleting = Console.ReadLine();

			//var r = JsonConvert.SerializeObject(new Stuff() { Email = "Email@gmail.com" });

			//var stringstuff = new StringContent(r, Encoding.UTF8, "application/json");

			var res = client.DeleteAsync("http://localhost:63040/api/Administrators/" + deleting).GetAwaiter().GetResult();

			Console.ReadLine();

		}


		public static void PostChallenges()
		{
			var client = new HttpClient();

			var r = JsonConvert.SerializeObject(new Questionlike() { Objective = "html", Question = "what is html", Answer = "I dont know" });

			var stringstuff = new StringContent(r, Encoding.UTF8, "application/json");

			var res = client.PostAsync("http://localhost:63040/api/Challenges", stringstuff).GetAwaiter().GetResult();


			var ri = res.Content.ReadAsStringAsync().Result;
			var p = JsonConvert.DeserializeObject<Questionlike>(ri);

			Console.WriteLine(p.QuestionNumber);

			Console.ReadLine();

		}


		public static void PutChallenges()
		{
			var client = new HttpClient();

			var questioning = new Questionlike() { QuestionNumber = 2, Question = "Question100", Objective = "xhtml", Answer = "xhtml is gone" };


			var r = JsonConvert.SerializeObject(questioning);

			var stringstuff = new StringContent(r, Encoding.UTF8, "application/json");

			var res = client.PutAsync("http://localhost:63040/api/Challenges/" + questioning.QuestionNumber, stringstuff).GetAwaiter().GetResult();


			var ri = res.Content.ReadAsStringAsync().Result;
			var p = JsonConvert.DeserializeObject<Questionlike>(ri);

			Console.WriteLine(p.QuestionNumber);

			Console.ReadLine();

		}

		public static void DeleteChallenges()
		{
			var client = new HttpClient();

			Console.WriteLine("Write the QuestionNumber of the Question you want to delete");
			var deleting = Console.ReadLine();
			//int deletingnum = 0;
			//int.TryParse(deleting,out deletingnum);
			//var r = JsonConvert.SerializeObject(new Stuff() { Email = "Email@gmail.com" });

			//var stringstuff = new StringContent(r, Encoding.UTF8, "application/json");

			var res = client.DeleteAsync("http://localhost:63040/api/Challenges/" + deleting).GetAwaiter().GetResult();

			Console.ReadLine();

		}

		public class Stuff
		{
			public string Email { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Psswrd { get; set; }
		}
		public class Questionlike
		{
			public int QuestionNumber { get; set; }
			public string Objective { get; set; }
			public string Question { get; set; }
			public string Answer { get; set; }
		}
    }
}
