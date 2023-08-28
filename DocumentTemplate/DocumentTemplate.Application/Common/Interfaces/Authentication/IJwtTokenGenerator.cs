using DocumentTemplate.Domain.Entities;

namespace DocumentTemplate.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}