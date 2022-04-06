using Application.Models;

namespace Application.Interface;

public interface IIdentityService
{
    Task<string> GetUserNameAsync( int userId );
    Task<bool> AuthorizeAsync( int userId, string policyName );
    Task<(Result Result, int UserId)> CreateUserAsync( int userName, string name, string password );
    Task<Result> DeleteUserAsync( int userId );
}
