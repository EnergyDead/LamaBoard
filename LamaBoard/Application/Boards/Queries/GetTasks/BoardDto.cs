using Application.Mappings;
using Board = ScrumBoard.Models.Boards;

namespace Application.Boards.Queries.GetTasks;

public class BoardDto : IMapFrom<Board>
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
