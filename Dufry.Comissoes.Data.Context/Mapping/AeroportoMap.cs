using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class AeroportoMap : EntityTypeConfiguration<Aeroporto>
    {
        public const string TableName = "DimAeroporto";


        public AeroportoMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.Id_Aeroporto);

            // Properties
            Property(t => t.Id_TipoNegocio)
                .IsRequired();

            Property(t => t.Id_Filial)
                .IsRequired();

            Property(t => t.SiglaAeroporto)
                .HasMaxLength(4)
                .IsRequired();

        }
    }
}
