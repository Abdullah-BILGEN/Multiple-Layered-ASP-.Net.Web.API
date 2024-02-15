using BilgeCinema.Business.Manager;
using BilgeCinema.Business.Services;
using BilgeCinema.Data.Context;
using BilgeCinema.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BilgeCinema.WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers(); // controller kullanýlacak
			builder.Services.AddEndpointsApiExplorer(); // api Projesi 

			builder.Services.AddDbContext<BilgeCinemaContext>(option => option.UseInMemoryDatabase("BilgeCinemaDb"));

			builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			builder.Services.AddScoped<IMovieService, MovieManager>();

			builder.Services.AddSwaggerGen();
			// Swashbuckle.Asp.Net.Core paketini indirmeyi unutma !!

			var app = builder.Build();

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
