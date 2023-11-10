using N70.Identity.Application.Common.Identity.Services;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class QrCodeGeneratorService : IQrCodeGeneratorService
{
    public ValueTask<bool> GenerateToken(string message)
    {
        throw new NotImplementedException();
    }
}