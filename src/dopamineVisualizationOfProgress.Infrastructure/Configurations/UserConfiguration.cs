using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(User.MaxNameLength);

        builder.HasIndex(u => u.Name).IsUnique();

        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.RegisterDate).IsRequired();
    }
}