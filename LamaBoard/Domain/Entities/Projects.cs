namespace ScrumBoard.Models;

public class Projects
{
    public int Id { get; set; }
    public string Name { get; set; }
    public User Creater { get; set; }
    private readonly List<Boards> _boards = new List<Boards>();
    public List<Boards> Boards
    {
        get { return _boards; }
        set { }
    }
}