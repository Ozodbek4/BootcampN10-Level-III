namespace Interceptor.Api.Models;

public class UserDto
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public byte Age { get; set; }

    //public string EmailAddress { get; set; } = default!;

    public string Password { get; set; } = default!;
}