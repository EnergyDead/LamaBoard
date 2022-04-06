namespace ScrumBoard.Models;

public class Tasks
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    private readonly List<User> _users = new();
    public List<User> Users
    {
        get
        {
            return _users;
        }
        private set { }
    }
}
