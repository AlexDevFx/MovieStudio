using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStudio.Core.Users;

namespace MovieStudio.Data.Configurations;

public class DirectorsConfiguration: IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.HasOne(e => e.User)
            .WithOne(e => e.Director);

        builder.HasMany(e => e.Movies)
            .WithOne(e => e.Director);
    }
}