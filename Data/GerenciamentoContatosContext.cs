using GerenciamentoContatos.Data.Configuration;
using GerenciamentoContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoContatos.Data
{
    public class GerenciamentoContatosContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public GerenciamentoContatosContext(DbContextOptions opts) : base(opts)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
        }
    }
}
