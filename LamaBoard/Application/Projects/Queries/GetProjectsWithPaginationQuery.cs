using Application.Interfaces;
using Application.Mappings;
using Application.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Application.Projects.Queries;

public class GetProjectsWithPaginationQuery : IRequest<PaginatedList<ProjectBriefDto>>
{
    public int ListId { get; set; }
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetProjectsWithPaginationQueryHandler : IRequestHandler<GetProjectsWithPaginationQuery, PaginatedList<ProjectBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProjectsWithPaginationQueryHandler( IApplicationDbContext context, IMapper mapper )
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProjectBriefDto>> Handle( GetProjectsWithPaginationQuery request, CancellationToken cancellationToken )
    {
        return await _context.Projects
            .Where( x => x.Id == request.ListId )
            .OrderBy( x => x.Name )
            .ProjectTo<ProjectBriefDto>( _mapper.ConfigurationProvider )
            .PaginatedListAsync( request.PageIndex, request.PageSize );
    }
}
