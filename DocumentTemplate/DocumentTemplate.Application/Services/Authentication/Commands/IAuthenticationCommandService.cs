using DocumentTemplate.Application.Services.Authentication.Common;
using ErrorOr;

namespace DocumentTemplate.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password);
}