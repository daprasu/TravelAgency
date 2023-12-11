using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using TravelAgency.Core.ApplicationContracts;
using TravelAgency.Core.DTOs;
using TravelAgency.Core.RepositoriesContracts;
using TravelAgency.Infraestructure.Repositories;
using TravelAngecy.Infraestructure.Application;
using TravelAngecy.Infraestructure.Data;
using TravelAngecy.Infraestructure.Helpers;
using TravelAngecy.Infraestructure.Repositories;

namespace TravelAgency
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TravelAgency", Version = "v1" });
                DirectoryInfo directoryFiles = new DirectoryInfo(AppContext.BaseDirectory);
                FileInfo[] filesDirectory = directoryFiles.GetFiles("*.xml", SearchOption.AllDirectories);
                foreach (var item in filesDirectory)
                {
                    c.IncludeXmlComments(item.FullName, true);
                }
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("Default_CorsPolicy", o =>
                {
                    o.AllowAnyHeader();
                    o.AllowAnyMethod();
                    o.AllowAnyOrigin();
                });
            });
            // Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // DataBase Conection
            services.AddDbContext<AgenciaViajesSmartContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TravelAgency"))
            );
            // dependency injection
            services.AddTransient<IHotelApplication, HotelApplication>();
            services.AddTransient<IHotelRepository, HotelRepository>();
            services.AddTransient<IRoomApplication, RoomApplication>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IReservationApplication, ReservationApplication>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IGuestRepository, GuestRepository>();
            // validation required fields
            services.AddResponseParametersValidation();
            // Email Configuration
            services.Configure<EmailConfiguration>(options => Configuration.GetSection("EmailConfiguration").Bind(options));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TravelAgency v1"));


            app.UseCors("Default_CorsPolicy");

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
