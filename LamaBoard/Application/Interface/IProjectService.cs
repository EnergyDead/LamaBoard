using Application.Dto;
using Application.Models;

namespace Application.Interface;

public interface IProjectService
{
    public Task<PaginatedList<ProjectBriefDto>> PaginatedList( int page, int pageSize );
    public Task<ProjectDto> GetProject( int projectId );
    public Task<int> Create( ProjectDto project );
    public Task<bool> Update( ProjectDto project );
    public Task<bool> Delete( int id );
}
