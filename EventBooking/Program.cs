using EventBooking.DataAccess;
using EventBooking.Repositories;
using EventBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
            builder => builder.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod());

        });

        builder.Services.AddDbContext<EventBookingDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("EventBookingConnectionString")),
            ServiceLifetime.Scoped
        );


        //Dependency Injections
        builder.Services.AddTransient<IEventRepository, EventRepository>();

        var app = builder.Build();
        app.UseCors("AllowAll");
        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

