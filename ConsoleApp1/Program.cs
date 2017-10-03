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
			GetAdmininstrator();
			PostAdministrator();
			PutAdministrator();
			DeleteAdministrator();
		}

		public static void GetAdmininstrator()
		{
			var client = new HttpClient();

			var res = client.GetAsync("http://localhost:62075/api/Administrators").GetAwaiter().GetResult();

			if (res.IsSuccessStatusCode)
			{
				var r = res.Content.ReadAsStringAsync().Result;
				var p = JsonConvert.DeserializeObject<List<Stuff>>(r);

				foreach (var item in p)
				{
					Console.WriteLine(item);
					Console.WriteLine(item._email);

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

			var r = JsonConvert.SerializeObject(new Stuff() { _email = "jim" });

			var stringstuff = new StringContent(r, Encoding.UTF8, "application/json");

			var res = client.PostAsync("http://localhost:62075/api/Administrators",stringstuff).GetAwaiter().GetResult();


			var ri = res.Content.ReadAsStringAsync().Result;
			var p = JsonConvert.DeserializeObject<Stuff>(ri);

			Console.WriteLine(p._email);
			
			Console.ReadLine();

		}


		public static void PutAdministrator()
		{
			var client = new HttpClient();

			var r = JsonConvert.SerializeObject(new Stuff() { _email = "jim" });

			var stringstuff = new StringContent(r, Encoding.UTF8, "application/json");

			var res = client.PutAsync("http://localhost:62075/api/Administrators/things@gmail", stringstuff).GetAwaiter().GetResult();


			var ri = res.Content.ReadAsStringAsync().Result;
			var p = JsonConvert.DeserializeObject<Stuff>(ri);

			Console.WriteLine(p._email);

			Console.ReadLine();

		}


		public static void DeleteAdministrator()
		{
			var client = new HttpClient();

			var r = JsonConvert.SerializeObject(new Stuff() { _email = "jim" });

			var stringstuff = new StringContent(r, Encoding.UTF8, "application/json");

			var res = client.DeleteAsync("http://localhost:62075/api/Administrators/stuff@gmail").GetAwaiter().GetResult();

		}

		public class Stuff
		{
			public string _email { get; set; }
			public string _first_name { get; set; }
			public string _last_name { get; set; }
			public string _password { get; set; }
		}	
    }
}
