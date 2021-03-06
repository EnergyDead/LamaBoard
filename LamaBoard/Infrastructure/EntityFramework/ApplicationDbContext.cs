using Application.Interfaces;
using Domain.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.EntityFramework;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public DbSet<Users> Users => Set<Users>();

    public DbSet<Projects> Projects => Set<Projects>();

    public DbSet<Boards> Boards => Set<Boards>();

    public DbSet<Tasks> Tasks => Set<Tasks>();
}
