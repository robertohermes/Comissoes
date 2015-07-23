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
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);


            //modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new ControleAcessoMap());
                        

        }
  
        #region DbSet


        //public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ControleAcesso> ControleAcessos { get; set; }

        

        #endregion
    }
}