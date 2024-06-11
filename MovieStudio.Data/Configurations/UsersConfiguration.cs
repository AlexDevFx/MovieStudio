using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStudio.Core.Users;

namespace MovieStudio.Data.Configurations;

public class UsersConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(e => e.Updated)
            .ValueGeneratedOnUpdate();
        builder.Property(e => e.UserName)
            .HasMaxLength(100);
        builder.Property(e => e.FirstName)
            .HasMaxLength(50);
        builder.Property(e => e.SecondName)
            .HasMaxLength(50);
    }
}