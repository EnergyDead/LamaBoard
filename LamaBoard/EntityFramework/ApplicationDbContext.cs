using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext() { }

    public DbSet<Users> Users => Set<Users>();

    public DbSet<Projects> Projects => Set<Projects>();

    public DbSet<Boards> Boards => Set<Boards>();

    public DbSet<Tasks> Tasks => Set<Tasks>();

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

    public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options )
    : base( options )
    { }
}
