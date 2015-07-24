using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class LojaMap : EntityTypeConfiguration<Loja>
    {
        public const string TableName = "DimLoja";

        public LojaMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.Id_Loja);

            // Properties
            Property(t => t.Id_Filial)
                .IsRequired();

            Property(t => t.Id_TipoLoja)
                .IsRequired();

            Property(t => t.Id_Aeroporto)
                .IsRequired();

            Property(t => t.CodigoLojaAlternate)
                .HasMaxLength(2)
                .IsRequired();

            Property(t => t.NomeLoja)
                .HasMaxLength(30)
                .IsRequired();

        }
    }
}
