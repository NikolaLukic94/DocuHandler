using DocumentTemplate.Application.Common.Interfaces.Services;

namespace DocumentTemplate.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}