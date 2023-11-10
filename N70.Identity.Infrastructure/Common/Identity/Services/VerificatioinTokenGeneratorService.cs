using N70.Identity.Application.Common.Enums;
using N70.Identity.Application.Common.Identity.Models;
using N70.Identity.Application.Common.Identity.Services;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class VerificatioinTokenGeneratorService : IVerificationTokenGeneratorService
{
    public (VerificationToken Token, bool IsValid) Decode(string token)
    {
        throw new NotImplementedException();
    }

    public string GeneratorTokenAsync(VerificationType type, Guid userId)
    {
        throw new NotImplementedException();
    }
}