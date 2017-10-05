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

namespace DatatoLogic2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
           Configuration = configuration;
			//var builder = new ConfigurationBuilder().AddXmlFile(@"C:\Users\Chris\Source\Repos\RevatureProject2\RevatureProject2\SlackerRankData\App.config");
			//Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
			services.AddEntityFrameworkSqlServer();
			//services.AddDbContext<SlackerRankData.Model.ChallengerDBEntities>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")));
			//services.AddEntityFrameworkSqlServer();
			//Configuration.GetConnectionString("DefaultConnection");
			//services.AddEntityFrameworkSqlServer().AddDbContext<DbContext>(o => o.UseSqlServer("DefaultConnection"));
	
			
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
