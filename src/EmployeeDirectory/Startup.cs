using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeDirectory.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation.AspNetCore;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace EmployeeDirectory
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
			
			services.AddDbContext<EmployeeDirContext>(opt => opt.UseInMemoryDatabase("EmployeeDirectory"));
			services.AddMediatR();
			services.AddAutoMapper();
			services.AddMvc().AddFluentValidation(c => 
			    { 
				    c.RegisterValidatorsFromAssemblyContaining<Startup>();
					//c.ConfigureClientsideValidation(enabled: false);
					c.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
			    }).AddFeatureFolders();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Employee/Error");
            }

            app.UseStaticFiles();           

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
					template: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
