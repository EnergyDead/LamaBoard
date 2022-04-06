using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class User : IdentityUser
{
    public int Id { get; set; }
    public string Name { get; set; }
}
