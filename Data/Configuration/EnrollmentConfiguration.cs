using GerenciamentoContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace GerenciamentoContatos.Data.Configuration;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder
            .ToTable("enrollments");

        builder
            .Property(e => e.Observation)
            .HasColumnType("text")
            .HasDefaultValue("Não informado");

        builder
            .Property(e => e.EnrollmentCreationDate)
            .HasColumnType("text")
            .HasDefaultValue(DateTime.Now);

        builder
            .Property(e => e.Name)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(e => e.LastName)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(e => e.Responsibility)
            .IsRequired();

        builder
            .Property(e => e.Company)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(e => e.Country)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(e => e.State)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(e => e.City)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder
            .Property(e => e.PostalCode)
            .HasColumnType("varchar(10)")
            .IsRequired();

        builder
            .Property(e => e.DDD)
            .HasColumnType("varchar(5)")
            .IsRequired();

        builder
            .Property(e => e.Phone)
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder
            .Property(e => e.Email)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(e => e.RelationshipWithIBM)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(e => e.ShareData)
            .IsRequired();

        builder
            .Property(e => e.ContactForm)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder
            .Property(e => e.EnrollmentApproved)
            .IsRequired();
    }
}
