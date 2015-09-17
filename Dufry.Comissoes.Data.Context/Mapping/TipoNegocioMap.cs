using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class TipoNegocioMap : EntityTypeConfiguration<TipoNegocio>
    {
        public const string TableName = "DimTipoNegocio";


        public TipoNegocioMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.Id_TipoNegocio);

            // Properties
            Property(t => t.Id_TipoBusiness)
                .IsRequired();

            Property(t => t.Id_Empresa)
                .IsRequired();

            Property(t => t.CodigoEmpresaLegado)
                .HasMaxLength(2)
                .IsRequired();

            Property(t => t.CodigoTipoNegocioAlternate)
                .HasMaxLength(10)
                .IsRequired();

            Property(t => t.NomeTipoNegocio)
                .HasMaxLength(10)
                .IsRequired();

        }
    }
}
