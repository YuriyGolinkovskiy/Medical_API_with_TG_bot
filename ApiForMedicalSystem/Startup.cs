using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ApiForMedicalSystem.Models;

using System.Text.Json.Serialization;

namespace ApiForMedicalSystem
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<DatabaseContext>(opt =>
            //opt.UseInMemoryDatabase("DatabaseList"));

            //services.AddControllers()
            //    .AddJsonOptions(o =>
            //    {
            //        o.JsonSerializerOptions
            //        .ReferenceHandler = ReferenceHandler.Preserve;
            //    });

            services.AddDbContext<DatabaseContext>(opt =>
                opt.UseSqlServer(connection));
            
            services.AddTransient<User>();
            services.AddTransient<Test>();
            services.AddTransient<Disease>();
            services.AddTransient<Symptom>();
            services.AddTransient<AnswerUser>();        
            services.AddTransient<Coefficient>();
            services.AddTransient<Result>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiForMedicalSystem", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiForMedicalSystem v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
