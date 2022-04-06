using Application.Mappings;
using ScrumBoard.Models;

namespace Application.Boards.Queries.GetTasks;

public class TaskDto : IMapFrom<Tasks>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
