using DocumentTemplate.Domain.Entities;

namespace DocumentTemplate.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User user,
    string Token
);