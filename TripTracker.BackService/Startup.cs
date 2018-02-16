using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using TripTracker.BackService.Data;

namespace TripTracker.BackService
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddTransient<Models.Repository>();
			services.AddMvc();

      services.AddDbContext<TripContext>(options=> options.UseSqlite("Data Source=JeffsTrips.db"));

			services.AddSwaggerGen(options =>
					options.SwaggerDoc("v1", new Info { Title = "Trip Tracker", Version = "v1" })
			);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{

			app.UseSwagger();

			if (env.IsDevelopment() || env.IsStaging())
			{

				app.UseSwaggerUI(options =>
						options.SwaggerEndpoint("/swagger/v1/swagger.json", "Trip Tracker v1")
				);

			}

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();

			TripContext.SeedData(app.ApplicationServices);

		}
	}
}
