using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStudio.Core.Movies;

namespace MovieStudio.Data.Configurations;

public class MovieGenresConfiguration: IEntityTypeConfiguration<MovieGenre>
{
    public void Configure(EntityTypeBuilder<MovieGenre> builder)
    {
        builder.HasOne(e => e.Movie)
            .WithMany(e => e.Genres);
        
        builder.HasOne(e => e.Genre)
            .WithMany(e => e.Movies);
    }
}