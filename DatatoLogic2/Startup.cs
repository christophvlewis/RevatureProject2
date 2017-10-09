using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using DatatoLogic2.src;

namespace DatatoLogic2
{
    public class Startup
    {

		public static string ConnectionString;

        public Startup(IConfiguration configuration)
        {
           Configuration = configuration;
			//var builder = new ConfigurationBuilder().AddXmlFile(@"C:\Users\Chris\Source\Repos\RevatureProject2\RevatureProject2\SlackerRankData\App.config");
			//Configuration = builder.Build();

			//var builder = new ConfigurationBuilder().AddJsonFile(@"C:\Users\Chris\Source\Repos\RevatureProject2\RevatureProject2\DatatoLogic2\appsettings.json");

			//var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

			//var builder = new ConfigurationBuilder().AddJsonFile(@"C:\Program Files (x86)\Jenkins\workspace\RevatureProject2\DatatoLogic2\appsettings.json");

			//builder.AddEnvironmentVariables();
			//Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
			services.AddEntityFrameworkSqlServer();

			//services.AddDbContext<ChallengerDBContext>(options =>
			//	options.UseSqlServer(Configuration.GetConnectionString("ChallengerDBEntities")));

			//services.AddScoped<AdministratorLogic>
			ConnectionString = Configuration.GetConnectionString("ChallengerDBEntities");

		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }


}
