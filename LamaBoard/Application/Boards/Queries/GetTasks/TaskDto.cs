using Application.Mappings;
using Domain.Entities;

namespace Application.Boards.Queries.GetTasks;

public class TaskDto : IMapFrom<Tasks>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
