﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Dufry.Comissoes.Data.Context.Config;
using Dufry.Comissoes.Data.Context.Mapping;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context
{
    public class BIVendasContext : BaseDbContext
    {
        public BIVendasContext()
            : base("Dufry.Vendas_DMEntities_BI")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BIVendasContext>(null);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new LojaMap());
            modelBuilder.Configurations.Add(new FilialMap());
            modelBuilder.Configurations.Add(new EmpresaMap());
            modelBuilder.Configurations.Add(new ColaboradorMap());

        }

        #region DbSet


        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Colaborador> Colaboradors { get; set; }



        #endregion

    }
}
