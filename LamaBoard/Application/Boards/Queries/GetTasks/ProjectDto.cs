using Application.Mappings;
using ScrumBoard.Models;

namespace Application.Boards.Queries.GetTasks;

public class ProjectDto : IMapFrom<Projects>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public BoardDto BoardDto { get; set; }
}
