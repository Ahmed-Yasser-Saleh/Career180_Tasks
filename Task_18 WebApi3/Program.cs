
using Microsoft.EntityFrameworkCore;
using Task_18_WebApi3.Models.Course;
using Task_18_WebApi3.testdb.Models;

namespace Task_18_WebApi3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // register servide
            builder.Services.AddDbContext<CourseContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Course")));
            builder.Services.AddDbContext<TestContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("Test")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
