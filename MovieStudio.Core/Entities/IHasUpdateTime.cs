namespace MovieStudio.Core.Entities;

public interface IHasUpdateTime
{
    DateTime? Updated { get; set; }
}