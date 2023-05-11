using FixxoApi2.Contexts;
using FixxoApi2.Middleware;
using FixxoApi2.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FixxoApi2
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


            builder.Services.AddDbContext<DataContext>(x =>
                x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));

            //Inject
            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<ContactRepository>();
            builder.Services.AddScoped<TagRepository>();


            var app = builder.Build();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            app.UseMiddleware<ApiKeyMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}