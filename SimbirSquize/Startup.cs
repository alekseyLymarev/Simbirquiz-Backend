using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using SimbirSquize.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SimbirSquize.Data.Dtos;
using SimbirSquize.Data.Testing;
using SimbirSquize.Services.Courses;
using SimbirSquize.Services.Lessons;
using SimbirSquize.Services.Questions;

namespace SimbirSquize
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
            services.AddDbContext<IdentityContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("IdentityContext"),
                    new MySqlServerVersion(new Version(8, 0, 25))));
            
            services.AddDbContext<TestingContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("TestingContext"),
                    new MySqlServerVersion(new Version(8, 0, 25))));
            
            services.AddDatabaseDeveloperPageExceptionFilter();
            
            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.Audience = "http://localhost:5000/";
                    options.Authority = "http://localhost:5001/";   
                });
            services.AddRazorPages();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<ICoursesService, CoursesService>();
            services.AddTransient<IQuestionsService, QuestionService>();
            services.AddTransient<ILessonsService, LessonService>();
            
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
            });
            app.UseSwagger();
            
            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}