using Application.Mappings;
using Domain.Entities;

namespace Application.Boards.Queries.GetTasks;

public class BoardDto : IMapFrom<Boards>
{
    public BoardDto()
    {
        Boards = new List<TaskDto>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Prioryty { get; set; }
    public IList<TaskDto> Boards { get; set; }
}
