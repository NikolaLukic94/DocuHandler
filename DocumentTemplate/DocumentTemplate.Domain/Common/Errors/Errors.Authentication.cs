using ErrorOr;

namespace DocumentTemplate.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "Credentials proided are not valid."
        );
    }
}