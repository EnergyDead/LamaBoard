namespace Domain.Entities;

public class Users
{
    public int Id { get; set; }
    public string Name { get; set; }

    private readonly List<Tasks> _tasks = new();
    public List<Tasks> Tasks
    {
        get
        {
            return _tasks;
        }
        private set { }
    }

    private readonly List<Projects> _projects = new();
    public List<Projects> Projects
    {
        get
        {
            return _projects;
        }
        private set { }
    }
}
