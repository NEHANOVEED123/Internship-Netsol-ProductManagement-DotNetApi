using Microsoft.EntityFrameworkCore;
using Internship_Netsol_ProductManagement_DotNetApi.DAL;
using Internship_Netsol_ProductManagement_DotNetApi.Interfaces;
using Internship_Netsol_ProductManagement_DotNetApi.Repository;
using Internship_Netsol_ProductManagement_DotNetApi.BL;

namespace Internship_Netsol_ProductManagement_DotNetApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();//This line registers the controllers with the dependency injection (DI) container. Controllers are responsible for handling HTTP requests in an MVC pattern.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
