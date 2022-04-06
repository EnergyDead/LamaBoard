using Application.Interface;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<User> _userManager;
    private readonly IUserClaimsPrincipalFactory<User> _userFactory;
    private readonly IAuthorizationService _authorizationService;
    public IdentityService(
    UserManager<User> userManager,
    IUserClaimsPrincipalFactory<User> userFactory,
    IAuthorizationService authorizationService )
    {
        _userManager = userManager;
        _userFactory = userFactory;
        _authorizationService = authorizationService;
    }
    public async Task<bool> AuthorizeAsync( int userId, string policyName )
    {
        var user = _userManager.Users.SingleOrDefault( u => u.Id == userId );

        if ( user == null )
        {
            return false;
        }

        var principal = await _userFactory.CreateAsync( user );

        var result = await _authorizationService.AuthorizeAsync( principal, policyName );

        return result.Succeeded;
    }

    public async Task<(Result Result, int UserId)> CreateUserAsync( int userName, string name, string password )
    {
        var user = new User
        {
            Name = name
        };

        var result = await _userManager.CreateAsync( user, password );

        return (result.Succeeded ? Result.Success() : Result.Failure( new List<string>() { "errors" } ), user.Id);
    }

    public Task<Result> DeleteUserAsync( int userId )
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetUserNameAsync( int userId )
    {
        var user = await _userManager.Users.FirstAsync( u => u.Id == userId );

        return user.Name;
    }
}
