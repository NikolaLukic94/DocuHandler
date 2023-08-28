using DocumentTempate.API.Controllers;
using DocumentTemplate.Application.Common.Interfaces.Authentication;
using DocumentTemplate.Application.Services.Authentication.Commands;
using DocumentTemplate.Application.Services.Authentication.Common;
using DocumentTemplate.Application.Services.Authentication.Query;
using DocumentTemplate.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DocumentTemplate.API.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // private readonly IAuthenticationCommandService _authenticationCommandService;
        // private readonly IAuthenticationQueryService _authenticationQueryService;
        // public AuthenticationController(
        //     IAuthenticationCommandService authenticationCommandService,
        //     IJwtTokenGenerator jwtTokenGenerator,
        //     IAuthenticationQueryService authenticationQueryService)
        // {
        //     _authenticationCommandService = authenticationCommandService;
        //     _authenticationQueryService = authenticationQueryService;
        // }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationCommandService.Register(request);

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }

        private static AuthenticationResponse MapAuthResult(ErrorOr<AuthenticationResult> authResult)
        {
            return new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token
            );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationQueryService.Login(
                request.Email,
                request.Password
            );

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }
    }
}
