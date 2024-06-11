using MovieStudio.Core.Contracts;

namespace MovieStudio.Infrastructure;

public class ClockProvider: IClockProvider
{
    public DateTime Now => DateTime.UtcNow;
}