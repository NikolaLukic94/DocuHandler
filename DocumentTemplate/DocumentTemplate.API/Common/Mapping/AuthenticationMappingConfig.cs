using DocumentTemplate.Application.Authentication.Commands.Register;
using DocumentTemplate.Application.Authentication.Common;
using DocumentTemplate.Application.Authentication.Queries.Login;
using DocumentTemplate.Contracts.Authentication;
using Mapster;

namespace DocumentTempate.API.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            //.Map(dest => dest.Token, src => src.Token)
            .Map(desc => desc, src => src.User);
    }
}