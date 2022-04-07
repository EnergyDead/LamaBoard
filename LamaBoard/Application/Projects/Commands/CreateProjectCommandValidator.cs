using Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Projects.Commands;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateProjectCommandValidator( IApplicationDbContext context )
    {
        _context = context;
    }

    public async Task<bool> BeUniqueName( string name, CancellationToken cancellationToken )
    {
        return await _context.Projects.AllAsync( p => p.Name == name, cancellationToken );
    }
}
