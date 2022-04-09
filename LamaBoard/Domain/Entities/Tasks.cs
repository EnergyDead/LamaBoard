namespace Domain.Entities;

public class Tasks
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    private readonly List<Users> _users = new();
    public List<Users> Users
    {
        get
        {
            return _users;
        }
        private set { }
    }
}
