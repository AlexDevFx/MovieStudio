using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStudio.Core.Users;

namespace MovieStudio.Data.Configurations;

public class ActorsConfiguration: IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.Property(e => e.Updated)
            .ValueGeneratedOnUpdate();
        builder.Ignore(e => e.Movies);
        
        builder.OwnsOne(e => e.Address,
            address =>
            {
                address.Property(a => a.Apartment).HasMaxLength(5);
                address.Property(a => a.City).HasMaxLength(40);
                address.Property(a => a.Street).HasMaxLength(200);
                address.Property(a => a.PostIndex).HasMaxLength(10);
            });
        builder.HasOne(e => e.User)
            .WithOne(e => e.Actor);

        builder.Property(e => e.Compensation).HasDefaultValue(0m);
        builder.HasMany(e => e.Offers)
            .WithOne(e => e.Actor);
    }
}