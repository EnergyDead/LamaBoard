namespace Application.Boards.Queries.GetTasks;

public class Boards
{
    public ProjectDto Project { get; set; }
    public IList<BoardDto> BoardsList { get; set; } = new List<BoardDto>();
}
