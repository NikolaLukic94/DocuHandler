using DocumentTemplate.Domain.Entities;

namespace DocumentTemplate.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);