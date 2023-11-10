using N70.Identity.Domain.Entities;
using N70.Identity.Application.Common.Enums;
using N70.Identity.Application.Common.Identity.Models;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IVerificationTokenGeneratorService
{
    string GeneratorTokenAsync(VerificationType type, Guid userId);

    (VerificationToken Token, bool IsValid) Decode(string token);
}