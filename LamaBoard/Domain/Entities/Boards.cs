namespace Domain.Entities;

public class Boards
{
    public int Id { get; set; }
    public int Prioryty { get; set; }
    private readonly List<Tasks> _tasks = new();
    public List<Tasks> Tasks
    {
        get
        {
            return _tasks;
        }
        set { }
    }
}
