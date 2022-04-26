using Application.Dto;
using Application.Interface;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace LamaBoard.Controllers;

[Route( "api/[controller]" )]
[ApiController]
public class ProjectController
{
    private readonly IProjectService _projectService;

    public ProjectController( IProjectService projectService )
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<PaginatedList<ProjectBriefDto>> GetProjectsWithPagination( int page, int pageSize )
    {
        return await _projectService.PaginatedList( page, pageSize );
    }

    [HttpGet( "{id}" )]
    public async Task<ProjectDto> Get( int id )
    {
        return await _projectService.GetProject( id );
    }

    [HttpPost]
    public async Task<int> Create( ProjectDto project )
    {
        return await _projectService.Create( project );
    }

    [HttpPut( "{id}" )]
    public async Task<bool> Update( int id, [FromBody] ProjectDto project )
    {
        return await _projectService.Update( project );
    }

    [HttpDelete( "{id}" )]
    public async Task<bool> Delete( int id )
    {
        return await _projectService.Delete( id );
    }
}
