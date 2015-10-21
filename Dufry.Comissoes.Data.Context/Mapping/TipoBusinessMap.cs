using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class TipoBusinessMap : EntityTypeConfiguration<TipoBusiness>
    {
        public const string TableName = "DimTipoBusiness";


        public TipoBusinessMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.Id_TipoBusiness);

            // Properties
            Property(t => t.CodigoTipoBusinessAlternate)
                .IsRequired();

            Property(t => t.CodigoNegocio)
                .HasMaxLength(3)
                .IsRequired();

            Property(t => t.NomeTipoBusiness)
                .HasMaxLength(30)
                .IsRequired();

        }
    }
}
