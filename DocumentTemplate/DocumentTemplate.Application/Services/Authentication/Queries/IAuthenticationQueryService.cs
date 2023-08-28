using DocumentTemplate.Application.Services.Authentication.Common;
using ErrorOr;

namespace DocumentTemplate.Application.Services.Authentication.Query;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(
        string Email,
        string Password);
}