using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DayConfiguration : IEntityTypeConfiguration<Day>
{
    public void Configure(EntityTypeBuilder<Day> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Date).IsRequired();

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(d => new { d.UserId, d.Date }).IsUnique();

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Days_Hours_NonNegative",
                "\"HardWork\" >= 0 AND \"UncontrolledWork\" >= 0 AND \"StrengthTraining\" >= 0 " +
                "AND \"CardioTraining\" >= 0 AND \"DopamineProcrastination\" >= 0");

            t.HasCheckConstraint("CK_Days_Hours_MaxSum",
                "\"HardWork\" + \"UncontrolledWork\" + \"StrengthTraining\" " +
                "+ \"CardioTraining\" + \"DopamineProcrastination\" <= 15");
        });
    }
}