using Application.Mappings;
using Domain.Entities;

namespace Application.Boards.Queries.GetTasks;

public class ProjectDto : IMapFrom<Domain.Entities.Projects>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public BoardDto BoardDto { get; set; }
}
