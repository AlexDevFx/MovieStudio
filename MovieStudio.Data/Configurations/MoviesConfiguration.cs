using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStudio.Core.Movies;

namespace MovieStudio.Data.Configurations;

public class MoviesConfiguration: IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(e => e.Updated)
            .ValueGeneratedOnUpdate();
        builder.Property(e => e.Title)
            .HasMaxLength(200)
            .IsRequired()
            .IsUnicode();
        builder.Property(e => e.Description)
            .HasMaxLength(1000)
            .IsUnicode();
        builder.Property(e => e.Budget)
            .HasDefaultValue(0m)
            .IsRequired();
        builder.Property(e => e.Duration)
            .IsRequired();
    }
}