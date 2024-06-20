using CapitalPlacement.Configurations;
using CapitalPlacement.DataBase;
using CapitalPlacement.Services;
using CapitalPlacement.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace CapitalPlacement
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<CapitalDbContext>(options =>
            options.UseCosmos(
                configuration["CosmosDb:PrimaryConnectionString"],
                configuration["CosmosDb:Database"]
            ));

            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Capital Placement Public API v1.0", Version = "v1" });
                opt.AddSecurityDefinition("CapitalPlacementApiAuth", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Input Valid Access token to access this API"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "CapitalApiAuth"
                            }
                        }, new List<string>()
                    }
                });
            });
            builder.Services.AddAutoMapper(typeof(MapperConfig));

            builder.Services.AddTransient(typeof(IProgramManager), typeof(ProgramManager));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var context = service.GetService<CapitalDbContext>();
                context.Database.EnsureCreated();

            }


            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Capital Placement Public API V1");
                });
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
