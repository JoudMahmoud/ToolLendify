using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToolLendify.Application.Services;
using ToolLendify.Domain.Entities;
using ToolLendify.Infrastructure.DataSeed;
using ToolLendify.Infrastructure.DbContext;

namespace ToolLendify.Presentation
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			#region Configure Services

			// Add services to the container
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// Configure DbContext
			builder.Services.AddDbContext<ToolLendifyDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings"));
			});

			// Register Identity services
			builder.Services.AddIdentity<User, IdentityRole>(options =>
			{
				// Require confirmed email account for sign-in
				options.SignIn.RequireConfirmedAccount = true;
			})
			.AddEntityFrameworkStores<ToolLendifyDbContext>()
			.AddDefaultTokenProviders();

			// Configure Authentication
			builder.Services.AddAuthentication()
				.AddJwtBearer(IdentityConstants.BearerScheme, options =>
				{
					// Configure JWT options here if needed
				});

			// Register custom services
			builder.Services.AddScoped<RoleService>();

			#endregion

			var app = builder.Build();

			#region Seed Data

			// Seed roles
			using (var scope = app.Services.CreateScope())
			{
				var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
				await RoleSeeder.SeedRolesAsync(roleManager);
			}

			#endregion

			#region Configure Middleware

			// Configure the HTTP request pipeline
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();

			// Map controllers
			app.MapControllers();

			#endregion

			app.Run();
		}
	}
}
