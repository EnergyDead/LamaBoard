namespace ScrumBoard.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string? Photo { get; set; }
    private readonly List<Tasks> _tasks = new();
    public List<Tasks> Tasks
    {
        get
        {
            return _tasks;
        }
        private set { }
    }
}
