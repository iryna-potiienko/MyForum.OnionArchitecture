using Domain.Mapper;
using Domain.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Model.Model;
using Persistence;
using Persistence.Repository;

namespace WebAPI
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
            //services.AddApplication();
            services.AddPersistence(Configuration);

            InitServices(services);

            InitRepositories(services);

            InitMappers(services);

            services.AddControllers();
            
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebAPI", Version = "v1"}); });
        }

        private static void InitServices(IServiceCollection services)
        {
            services.AddScoped<ChapterService>();
            services.AddScoped<SubjectService>();
            services.AddScoped<MessageService>();
            services.AddScoped<UserProfileService>();
            services.AddScoped<RoleService>();
        }

        private static void InitRepositories(IServiceCollection services)
        {
            services.AddScoped<ChapterRepository>();
            services.AddScoped<SubjectRepository>();
            services.AddScoped<MessageRepository>();
            services.AddScoped<UserProfileRepository>();
            services.AddScoped<RoleRepository>();
        }

        private static void InitMappers(IServiceCollection services)
        {
            services.AddScoped<ChapterMapper>();
            services.AddScoped<SubjectMapper>();
            services.AddScoped<MessageMapper>();
            services.AddScoped<UserProfileMapper>();
            services.AddScoped<RoleMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}