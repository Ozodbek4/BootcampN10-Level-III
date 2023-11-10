using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Application.Common.Constants;
using N70.Identity.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class TokenGeneratorService : ITokenGeneratorService
{
    private string _secretKey = "c9c10c2c-8798-4859-85d3-bb87c95d6395";

    public string GetToken(User user) =>
        GetToken(user);

    public JwtSecurityToken GetJwtToken(User user)
    {
        var claims = GetClaims(user);

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(issuer: "My.ServerApp",
            audience: "my.App",
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(5),
            signingCredentials: credentials);
    }

    public List<Claim> GetClaims(User user) =>
        new List<Claim>
        {
            new(ClaimTypes.Email, user.EmailAddress),
            new(ClaimConstants.UserId, user.Id.ToString()),
        };
}