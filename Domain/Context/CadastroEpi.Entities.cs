using CadastroEpi.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroEpi.Db
{
    public partial class Entities : DbContext
    {
        #region Constructors

        /// <summary>
        /// Initialize a new Entities object.
        /// </summary>
        public Entities() :
                base(@"name=DefaultConnection")
        {
            Configure();
        }

        /// <summary>
        /// Initializes a new Entities object using the connection string found in the 'Entities' section of the application configuration file.
        /// </summary>
        public Entities(string nameOrConnectionString) :
                base(nameOrConnectionString)
        {
            Configure();
        }

        private void Configure()
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true;
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //throw new UnintentionalCodeFirstException();
        }

    
        /// <summary>
        /// There are no comments for Funcionario in the schema.
        /// </summary>
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
    
        /// <summary>
        /// There are no comments for Empresa in the schema.
        /// </summary>
        public virtual DbSet<Empresa> Empresas { get; set; }
    
        /// <summary>
        /// There are no comments for Funcao in the schema.
        /// </summary>
        public virtual DbSet<Funcao> Funcaos { get; set; }
    
        /// <summary>
        /// There are no comments for Epi in the schema.
        /// </summary>
        public virtual DbSet<Epi> Epis { get; set; }
    
        /// <summary>
        /// There are no comments for FuncionarioEpi in the schema.
        /// </summary>
        public virtual DbSet<FuncionarioEpi> FuncionarioEpis { get; set; }
    }
}
