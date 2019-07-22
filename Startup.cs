using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using LibrarioAPI.Models;
using LibrarioAPI.Services;
namespace LibrarioAPI {
	public class Startup {
		public Startup (IConfiguration configuration)
		{
			Configuration = configuration;
		}

		readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; 


		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices (IServiceCollection services)
		{
			services.Configure<LibrarioDatabaseSettings> (
			    Configuration.GetSection (nameof (LibrarioDatabaseSettings)));

			services.AddSingleton<ILibrarioDatabaseSettings> (sp =>
			     sp.GetRequiredService<IOptions<LibrarioDatabaseSettings>> ().Value);


			services.AddSingleton<ItemService> ();
			services.AddSingleton<ValueService> ();

			services.AddCors(options =>
			{
				options.AddPolicy(MyAllowSpecificOrigins,
				builder =>
				{
					builder.WithOrigins("http://localhost:8080",
										"http://www.contoso.com");
				});
			});

			services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure (IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment ()) {
				app.UseDeveloperExceptionPage ();
			} else {
				app.UseHsts ();
			}
			app.UseStaticFiles ();

			app.UseCors(MyAllowSpecificOrigins);

			app.UseMvc (routes =>
			{
				routes.MapRoute ("default", "api/v/{action?}/{id?}", defaults: new { controller = "Item"});

				routes.MapRoute ("Spa", "v/{*url}", defaults: new { controller = "App", action = "Spa" });
			});

			/*app.UseStaticFiles ();

			app.UseHttpsRedirection ();
			//app.UseMvc ();
			app.UseMvc (routes =>
			{
				routes.MapRoute ("default", "{controller}/{action?}/{id?}");
			});*/
		}
	}
}
