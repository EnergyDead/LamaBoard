using Application.Interfaces;
using Domain.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Infrastructure.Identity;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.EntityFramework;

public class ApplicationDbContext : ApiAuthorizationDbContext<Identity.User>, IApplicationDbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions ) : base( options, operationalStoreOptions )
    {
    }

    public DbSet<Projects> Projects => Set<Projects>();

    public DbSet<Boards> Boards => Set<Boards>();

    public DbSet<Tasks> Tasks => Set<Tasks>();
}
