using Application.Behaviours;
using Application.Projects.Queries;
using FluentValidation;
using Infrastructure.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddAutoMapper( Assembly.GetExecutingAssembly() );
builder.Services.AddValidatorsFromAssembly( Assembly.GetExecutingAssembly() );
builder.Services.AddMediatR( Assembly.GetExecutingAssembly() );
builder.Services.AddControllers();
// builder.Services.AddTransient<GetProjectsWithPaginationQuery>();
// builder.Services.AddMediatR( typeof( GetProjectsWithPaginationQuery ).GetTypeInfo().Assembly );
builder.Services.AddMediatR( typeof( Application.AssemblyReference ).Assembly );
// builder.Services.AddTransient( typeof( IPipelineBehavior<,> ), typeof( UnhandledExceptionBehaviour<,> ) );
// builder.Services.AddTransient( typeof( IPipelineBehavior<,> ), typeof( AuthorizationBehaviour<,> ) );
// builder.Services.AddTransient( typeof( IPipelineBehavior<,> ), typeof( ValidationBehaviour<,> ) );
builder.Services.AddTransient( typeof( IPipelineBehavior<,> ), typeof( PerformanceBehaviour<,> ) );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();

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
