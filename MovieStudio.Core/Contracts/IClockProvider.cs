namespace MovieStudio.Core.Contracts;

public interface IClockProvider
{
    DateTime Now { get; }
}