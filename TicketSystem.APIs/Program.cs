
using Microsoft.EntityFrameworkCore;
using TicketSystem.BL.Managers;
using TicketSystem.DAL.Context;
using TicketSystem.DAL.Repos.TicketRepo;

namespace TicketSystem.APIs
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

            #region Database

            var connectionString = builder.Configuration.GetConnectionString("TicketDb");
            builder.Services.AddDbContext<TicketContext>(options => options.UseSqlServer(connectionString));

            #endregion

            #region Repos

            builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();

            #endregion

            #region Managers

            builder.Services.AddScoped<ITicketsManager, TicketsManager>();

            #endregion

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