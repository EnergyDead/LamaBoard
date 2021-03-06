using Microsoft.EntityFrameworkCore;
using Domain.Entities;


namespace Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.Projects> Projects { get; }
    DbSet<Domain.Entities.Boards> Boards { get; }
    DbSet<Tasks> Tasks { get; }
    DbSet<Users> Users { get; }
    Task<int> SaveChangesAsync( CancellationToken cancellationToken );
    int SaveChanges();
}
