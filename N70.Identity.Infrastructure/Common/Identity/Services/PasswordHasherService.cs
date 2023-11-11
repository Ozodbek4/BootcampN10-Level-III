using N70.Identity.Application.Common.Identity.Services;
using Bc = BCrypt.Net.BCrypt;
namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string PasswordHasher(string password) =>
        Bc.HashPassword(password);

    public bool ValidatePassword(string password, string hashedPassword) =>
        Bc.Verify(password, hashedPassword);
}