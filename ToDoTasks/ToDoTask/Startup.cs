using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using Service.Services;

namespace ToDoTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            const string connection = @"Server = .\SQLEXPRESS; Database = ToDoTasks.Development; Trusted_Connection = true;";
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            // Application's repositories within repository layer
            services.AddTransient<IToDoTaskRepository, ToDoTaskRepository>();
            
            // Application's services within service layer
            services.AddTransient<IToDoTaskService, ToDoTaskService>();
            services.AddTransient<IWorkingWithFiles, WorkingWithFiles>();
            services.AddTransient<IApplicationUserServices, ApplicationUserServices>();
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=ToDoTasks}/{action=Index}");
            });
        }
    }
}
