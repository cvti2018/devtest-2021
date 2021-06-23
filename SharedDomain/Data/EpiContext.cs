using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class EpiContext : DbContext
    {
        public EpiContext(DbContextOptions<EpiContext> options) : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcao> Funcaos { get; set; }
        public DbSet<Epi> Epis { get; set; }
        public DbSet<FuncionarioEpi> FuncionarioEpis { get; set; }
    }
}