using Microsoft.EntityFrameworkCore;
using ScrumBoard.Models;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Projects> Projects { get; }
    DbSet<ScrumBoard.Models.Boards> Boards { get; }
    DbSet<Tasks> Tasks { get; }
    Task<int> SaveChangesAsync( CancellationToken cancellationToken );
}
