using FluentValidation;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Application.Projects;
using Application.Interface;
using Application.Interfaces;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer( "name=ConnectionStrings:DefaultConnection" ), ServiceLifetime.Singleton );
builder.Services.AddLogging();
builder.Services.AddScoped<IApplicationDbContext>( provider => provider.GetRequiredService<ApplicationDbContext>() );


builder.Services.AddAutoMapper( Assembly.GetExecutingAssembly() );
builder.Services.AddValidatorsFromAssembly( Assembly.GetExecutingAssembly() );
builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddScoped<IProjectService, ProjectService>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using ( var scope = app.Services.CreateScope() )
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        if ( context.Database.IsSqlServer() )
        {
            context.Database.Migrate();
        }
    }
    catch ( Exception ex )
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogError( ex, "An error occurred while migrating or seeding the database." );

    }

}

app.Run();
