using DocumentTemplate.Application.Common.Interfaces.Authentication;
using DocumentTemplate.Application.Common.Interfaces.Persistence;
using DocumentTemplate.Application.Services.Authentication.Common;
using DocumentTemplate.Domain.Common.Errors;
using DocumentTemplate.Domain.Entities;
using ErrorOr;

namespace DocumentTemplate.Application.Services.Authentication.Query;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (
            _userRepository.GetUserByEmail(email) is not User user
            || user.Password != password)
        {
            // return new[] { Errors.Authentication.InvalidCredentials };
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}