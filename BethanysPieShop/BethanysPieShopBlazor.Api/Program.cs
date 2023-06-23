using BethanysPieShopBlazor.Api.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;
using BethanysPieShopBlazor.Services;

namespace BethanysPieShopBlazor.Api
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

			builder.Services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			HttpClient.DefaultProxy.Credentials = CredentialCache.DefaultCredentials;

			builder.Services.AddScoped<ICountryRepository, CountryRepository>();
			builder.Services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
			builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

			builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>
				(client => client.BaseAddress = new Uri("https://localhost:44340/"));
            builder.Services.AddHttpClient<ICountryDataService, CountryDataService>
                (client => client.BaseAddress = new Uri("https://localhost:44340/"));
            builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>
                (client => client.BaseAddress = new Uri("https://localhost:44340/"));

            builder.Services.AddCors(options =>
			{
				options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader());	
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.UseCors();

			app.MapControllers();

			app.Run();
		}
	}
}