using AutoMapper;
using JewelryWorkshopOrders.Bll;
using JewelryWorkshopOrders.Bll.Interfaces;
using JewelryWorkshopOrders.Bll.Mappers;
using JewelryWorkshopOrders.Bll.Services;
using JewelryWorkshopOrders.Dal;
using JewelryWorkshopOrders.Dal.Interfaces;
using JewelryWorkshopOrders.Dal.Repositories;
using JewelryWorkshopOrders.Dal.UnitOfWork;
using JewelryWorkshopOrders.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wkhtmltopdf.NetCore;

namespace JeweleryWorkshopOrders.API
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

            builder.Services.AddDbContext<JewelryWorkshopOrdersDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            });

            builder.Services.AddAutoMapper(typeof(BllAssemblyMarker));
            builder.Services.AddWkhtmltopdf("Infrastructure");
            builder.Services.AddScoped<DbContext, JewelryWorkshopOrdersDbContext>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IMaterialTypeRepository, MaterialTypeRepository>();
            builder.Services.AddScoped<IMaterialTypeService, MaterialTypeService>();
            builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
            builder.Services.AddScoped<IMaterialService, MaterialService>();
            builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IPriceRepository, PriceRepository>();
            builder.Services.AddScoped<IPriceService, PriceService>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IQuittanceService, QuittanceService>();
            
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://dev-8gpwok7eoznemrxr.us.auth0.com/";
                options.Audience = "https://localhost:7014";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(
                configurePolicy => configurePolicy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Content-Disposition", "Location"));

            app.UseAuthorization();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}