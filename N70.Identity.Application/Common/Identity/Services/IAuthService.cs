﻿using N70.Identity.Application.Common.Identity.Models;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IAuthService
{
    ValueTask<bool> RegisterAsync(RegisterDetails registerDetails);

    ValueTask<string> LoginAsync(LoginDetails loginDetails);

    ValueTask<bool> GrandRoleAsync(Guid userId, string roleType, Guid actionUserId);
}