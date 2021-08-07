using AwesomeGymLive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomeGymLive.Domain.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(x => x.Active)
                .IsRequired();
        }
    }
}
