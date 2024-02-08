using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SHG.Infrastructure.Database.Entities;

namespace SHG.Application;

public record AccessTokenDto(string? Issuer, string? Audience, double Expires, string Token);

public class TokenService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;

    public TokenService(IConfiguration configuration, UserManager<User> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<AccessTokenDto> GenereteJwtToken(User user)
    {

    }
}
