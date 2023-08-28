using ErrorOr;

namespace DocumentTemplate.Domain.Common.Errors;

public static partial class Errors
{
    public static partial class User
    {
        public static Error DuplicateEmail => Error.Validation(
            code: "User.DuplicateEmail",
            description: "Email is already taken."
        );
    }
}