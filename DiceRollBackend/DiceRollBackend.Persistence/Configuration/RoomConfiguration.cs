using DiceRollBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiceRollBackend.Persistence.Configuration;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("rooms");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Code)
            .IsRequired()
            .HasMaxLength(8);

        builder.HasMany(r => r.Users)
            .WithOne(u => u.Room)
            .HasForeignKey(u => u.RoomId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.ActiveUser)
            .WithMany()
            .HasForeignKey(r => r.ActiveUserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}