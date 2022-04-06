using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Boards.Queries.GetTasks;

public class GetTasksQuery : IRequest<Boards>
{
}

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, Boards>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTasksQueryHandler( IApplicationDbContext context, IMapper mapper )
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Boards> Handle( GetTasksQuery request, CancellationToken cancellationToken )
    {
        return new Boards
        {
            Project = await _context.Projects.AsNoTracking().ProjectTo<ProjectDto>( _mapper.ConfigurationProvider ).FirstAsync( cancellationToken ),
            BoardsList = await _context.Boards.AsNoTracking().ProjectTo<BoardDto>( _mapper.ConfigurationProvider ).OrderBy( t => t.Id ).ToListAsync( cancellationToken )
        };
    }
}
