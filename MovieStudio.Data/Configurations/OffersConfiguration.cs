using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStudio.Core.Movies;

namespace MovieStudio.Data.Configurations;

public class OffersConfiguration: IEntityTypeConfiguration<MovieOffer>
{
    public void Configure(EntityTypeBuilder<MovieOffer> builder)
    {
        builder.Property(e => e.Updated)
            .ValueGeneratedOnUpdate();
        builder.Property(e => e.Sent)
            .ValueGeneratedOnAdd();
        builder.HasOne(e => e.Movie)
            .WithMany(e => e.Offers);
        builder.HasOne(e => e.Actor)
            .WithMany(e => e.Offers);
    }
}