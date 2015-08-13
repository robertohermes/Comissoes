using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Dufry.Comissoes.Data.Context.Config;
using Dufry.Comissoes.Data.Context.Mapping;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context
{
    public class ComissoesContext : BaseDbContext
    {

        public ComissoesContext()
            : base("Dufry.ComissoesEntities_BI")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ComissoesContext>(null);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AusenciaRemuneradaMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new CategoriaPercentualMap());
            modelBuilder.Configurations.Add(new ControleAcessoMap());
            modelBuilder.Configurations.Add(new DolarMedioMap());
            modelBuilder.Configurations.Add(new DSRMap());
            modelBuilder.Configurations.Add(new PlanoMap());
            modelBuilder.Configurations.Add(new PlanoCategoriaMap());
            modelBuilder.Configurations.Add(new SelfServiceMap());

        }
  
        #region DbSet
        
        public DbSet<AusenciaRemunerada> AusenciaRemuneradas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CategoriaPercentual> CategoriaPercentuals { get; set; }
        public DbSet<ControleAcesso> ControleAcessos { get; set; }
        public DbSet<DolarMedio> DolarMedios { get; set; }
        public DbSet<DSR> DSRs { get; set; }
        public DbSet<Plano> Plano { get; set; }
        public DbSet<PlanoCategoria> PlanoCategorias { get; set; }
        public DbSet<SelfService> SelfServices { get; set; }

        #endregion
    }
}