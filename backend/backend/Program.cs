using backend.Data;
using backend.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options=>options.UseInMemoryDatabase("EmployeeDb"));
            builder.Services.AddCors(options => options.AddPolicy("MyCors", corsPolicybuilder => corsPolicybuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            WebApplication app = builder.Build();
            app.UseCors("MyCors");
            app.MapControllers();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(swaggerUIOptions=> { 
                    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                    swaggerUIOptions.RoutePrefix = string.Empty;
                });
            }
            app.Run();
        }
    }
}
