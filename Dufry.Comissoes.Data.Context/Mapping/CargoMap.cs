using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class CargoMap : EntityTypeConfiguration<Cargo>
    {
        public const string TableName = "DimCargo";

        public CargoMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.Id_Cargo);

            // Properties
            Property(t => t.CodigoCargoAlternate)
                .HasMaxLength(2)
                .IsRequired();

            Property(t => t.NomeCargo)
                .HasMaxLength(80)
                .IsRequired();

        }
    }
}
