using N70.Identity.Application.Common.Enums;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Application.Common.Notifications.Services;
using N70.Identity.Domain.Entities;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private readonly IVerificationTokenGeneratorService _verificationTokenGeneratorService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;
    private readonly IUserService _userService;

    public AccountService(IVerificationTokenGeneratorService verificationTokenGeneratorService, IEmailOrchestrationService emailOrchestrationService, IUserService userService)
    {
        _verificationTokenGeneratorService = verificationTokenGeneratorService;
        _emailOrchestrationService = emailOrchestrationService;
        _userService = userService;
    }

    public async ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken)
    {
        var createdUser = await _userService.CreateAsync(user, true, cancellationToken);

        var verificaitonToken  = _verificationTokenGeneratorService.GenerateToken(VerificationType.EmailAddressVerificaton,user.Id);

        var verificationEmailResult = await _emailOrchestrationService.SendMessageAsync(user.EmailAddress, $"Siz saytga hush kelibsiz - " +
            $"{verificaitonToken}");

        var result = verificationEmailResult;

        return result;
    }

    public ValueTask<bool> VerificationAsync(string token, CancellationToken cancellationToken = default)
    {
        if(token is null)
            throw new ArgumentNullException("invalid token");

        var verificationTokenResult = _verificationTokenGeneratorService.DecodeToken(token);

        if (!verificationTokenResult.IsValid)
            throw new InvalidOperationException("Invalid token");

        var result = verificationTokenResult.Token.Type switch
        {
            VerificationType.EmailAddressVerificaton => MarkAsEmailVerifiedAsync(verificationTokenResult.Token.UserId, VerificationType.EmailAddressVerificaton),
            _ => throw new InvalidOperationException("This method is not intended to accept other types of tokens")
        };

        return result;
    }

    public ValueTask<bool> MarkAsEmailVerifiedAsync(Guid userId, VerificationType verificationType)
    {
        return new (true);
    }
}