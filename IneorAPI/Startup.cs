using IneorBusiness.Enum;
using IneorBusiness.Infrastructure;
using IneorBusiness.Interfaces;
using IneorBusiness.Repository;
using IneorBusiness.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using static IneorAPI.Models.AppSettingsConnectionStrings;

namespace IneorAPI
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                
                    builder.WithOrigins(Configuration.GetSection("AllowedCors").Value)
                    .WithMethods("GET")
                    .WithMethods("POST")
                    .AllowAnyHeader()
                );
            });

            //Database Connection Start
            services.Configure<AppsettingsConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            var sqlConnectionStrings = new Dictionary<DatabaseEnum, string>();
            sqlConnectionStrings.Add(DatabaseEnum.SqlConnection, Configuration.GetConnectionString(DatabaseEnum.SqlConnection.ToString()));
            services.AddTransient<SqlConnectionDapper, SqlConnectionDapper>(x => { return new SqlConnectionDapper(sqlConnectionStrings); });

            //Database Connetion END


            //DI
            services.AddScoped<IBookService, BookService>();
            services.AddTransient<BookRepository, BookRepository>();

            services.AddMvcCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
