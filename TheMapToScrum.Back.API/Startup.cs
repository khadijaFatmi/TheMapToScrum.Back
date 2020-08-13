using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Text.Json;

using TheMapToScrum.Back.BLL;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.Repositories.Contract;
using TheMapToScrum.Back.Repositories.Repo;

namespace TheMapToScrum.Back.API
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

            string strConn = Configuration.GetConnectionString("DefaultConnection");


            //Injections de dépendances
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.EnableSensitiveDataLogging(true);
                options.UseSqlServer(strConn);
            });

            services.AddScoped<IProjectLogic, ProjectLogic>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IProductOwnerLogic, ProductOwnerLogic>();
            services.AddScoped<IProductOwnerRepository, ProductOwnerRepository>();

            services.AddScoped<IScrumMasterLogic, ScrumMasterLogic>();
            services.AddScoped<IScrumMasterRepository, ScrumMasterRepository>();

            services.AddScoped<IDeveloperLogic, DeveloperLogic>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();

            services.AddScoped<IUserStoryLogic, UserStoryLogic>();
            services.AddScoped<IUserStoryRepository, UserStoryRepository>();

            services.AddScoped<IDepartmentLogic, DepartmentLogic>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddScoped<ITeamLogic, TeamLogic>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            //services.AddControllers();

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(x => x.EnableEndpointRouting = false)
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeHtml;
                    
                }
            );
            
        }

        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }



    }
}
