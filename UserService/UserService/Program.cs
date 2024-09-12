
using DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserService.Interfaces;
using UserService.Repositories;
using AppContext = DataAccess.DatabaseContext.AppContext;

namespace UserService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppContext>( options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, UserService.Services.EmployeeService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "CustomPolicy",
                                  policy =>
                                  {
                                      policy.WithOrigins("", "")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                  });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CustomPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
