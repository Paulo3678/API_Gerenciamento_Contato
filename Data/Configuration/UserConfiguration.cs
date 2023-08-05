using GerenciamentoContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoContatos.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(u => u.Password)
                .HasColumnType("text")
                .IsRequired();

            builder
                .Property(u => u.Email)
                .HasColumnType("varchar(100)");

            builder
                .Property(u => u.DateOfCreation)
                .HasDefaultValueSql("getdate()")
                .IsRequired();
        }
    }
}
