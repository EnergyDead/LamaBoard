using Application.Dto;
using Application.Interface;
using Application.Interfaces;
using Application.Mappings;
using Application.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Logging;

namespace Application.Projects;

public class ProjectService : IProjectService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;


    public ProjectService( IApplicationDbContext context, IMapper mapper, ILogger logger )
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PaginatedList<ProjectBriefDto>> PaginatedList( int page, int pageSize )
    {
        return await _context.Projects
            .ProjectTo<ProjectBriefDto>( _mapper.ConfigurationProvider )
            .PaginatedListAsync( page, pageSize );
    }

    public async Task<ProjectDto> GetProject( int projectId )
    {
        return _context.Projects
            .ProjectTo<ProjectDto>( _mapper.ConfigurationProvider )
            .First( p => p.Id == projectId );
    }

    public async Task<int> Create( ProjectDto project )
    {
        var user = _context.Users.FirstOrDefault( u => u.Id == 2 );
        var newProject = new Domain.Entities.Projects()
        {
            Name = project.Name,
            Creater = user,
        };
        await _context.Projects.AddAsync( newProject );
        _context.SaveChanges();
        return newProject.Id;
    }

    public Task<bool> Update( ProjectDto project )
    {
        var newProject = _mapper.Map<Domain.Entities.Projects>( project );
        try
        {
            _context.Projects.Update( newProject );
            return Task.FromResult( true );
        }
        catch ( Exception ex )
        {
            string message = $"Upadte project error. {ex.Message}";
            _logger.LogInformation( message );
            return Task.FromResult( false );
        }
    }

    public Task<bool> Delete( int id )
    {
        try
        {
            var a = _context.Projects.FirstOrDefault( p => p.Id == id );
            _context.Projects.Remove( a );
            return Task.FromResult( true );
        }
        catch ( Exception ex )
        {
            string message = $"Delete project error. {ex.Message}";
            _logger.LogInformation( message );
            return Task.FromResult( false );
        }
    }
}
