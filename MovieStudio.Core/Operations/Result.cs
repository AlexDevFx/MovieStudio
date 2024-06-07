namespace MovieStudio.Core.Operations;

public record Result(string? Error = null)
{
    public bool Success => Error != null;
}