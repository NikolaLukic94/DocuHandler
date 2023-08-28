using DocumentTempate.API.Controllers;
using DocumentTemplate.Application.Authentication.Commands.Register;
using DocumentTemplate.Application.Authentication.Common;
using DocumentTemplate.Application.Authentication.Queries.Login;
using DocumentTemplate.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DocumentTemplate.API.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        // private readonly IMediator _mediator;
        private readonly ISender _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }

        private static AuthenticationResponse MapAuthResult(ErrorOr<AuthenticationResult> authResult)
        {
            return new AuthenticationResponse(
                authResult.Value.User.Id,
                authResult.Value.User.FirstName,
                authResult.Value.User.LastName,
                authResult.Value.User.Email,
                authResult.Value.Token
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }
    }
}
