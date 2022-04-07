using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Projects.Commands;

public class CreateProjectCommand : IRequest<int>
{
    public string Name { get; set; }
}

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProjectCommandHandler( IApplicationDbContext context )
    {
        _context = context;
    }

    public Task<int> Handle( CreateProjectCommand request, CancellationToken cancellationToken )
    {
        var entity = new Domain.Entities.Projects()
        {
            Name = request.Name
        };

        _context.Projects.Add( entity );

        throw new NotImplementedException();
    }
}