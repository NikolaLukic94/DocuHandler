using DocumentTemplate.Application.Authentication.Common;
using DocumentTemplate.Contracts.Authentication;
using Mapster;

namespace DocumentTempate.API.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(desc => dest, src => src.User);
    }
}