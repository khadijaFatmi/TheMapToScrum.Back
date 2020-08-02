using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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



            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(strConn);
            });
            services.AddScoped<IProjectLogic, ProjectLogic>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IBusinessManagerLogic, BusinessManagerLogic>();
            services.AddScoped<IBusinessManagerRepository, BusinessManagerRepository>();

            services.AddScoped<IDeveloperLogic, DeveloperLogic>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();



            services.AddScoped<IUserStoryLogic, UserStoryLogic>();
            services.AddScoped<IUserStoryRepository, UserStoryRepository>();

            services.AddScoped<IDepartmentLogic, DepartmentLogic>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddControllers();

            services.AddCors(); // Make sure you call this previous to AddMvc
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(x => x.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /* public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
         {
             if (env.IsDevelopment())
             {
                 app.UseDeveloperExceptionPage();
             }


             app.UseHttpsRedirection();

             app.UseCors("CorsPolicy");

             app.UseMvc();



             app.UseRouting();

             app.UseBusinessManagerization();

             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers();
             });


         }*/

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

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

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
