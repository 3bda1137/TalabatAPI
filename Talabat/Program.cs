
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Repository;
using Talabat.Repository.Data;

namespace Talabat
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
            });

            //register services
            //builder.Services.AddScoped<IGenericRepository<Product>, GenaricRepository<Product>>();
            //builder.Services.AddScoped<IGenericRepository<ProductBrand>, GenaricRepository<ProductBrand>>();
            //builder.Services.AddScoped<IGenericRepository<ProductCategory>, GenaricRepository<ProductCategory>>();
            //or use genaric Add Scoped

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenaricRepository<>));



            var app = builder.Build();

            #region MigrateAsync

            //use 'using' to dispose all resources After Finish
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbcontext = services.GetRequiredService<StoreContext>();
            //Ask CLR  to creating  object form DbContext 'StoreContext' Explicitly 
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await dbcontext.Database.MigrateAsync();
                await StoreDataSeeding.AddDateSeeding(dbcontext);

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Error Has been occured during update database");
            }

            #endregion

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
