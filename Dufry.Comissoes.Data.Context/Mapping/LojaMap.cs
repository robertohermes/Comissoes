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

            Property(t => t.Id_Grouping)
                .IsRequired();

            Property(t => t.Id_DataOpen)
                .IsRequired();

            Property(t => t.Id_DataClose)
                .IsRequired();

            Property(t => t.CodigoLojaAlternate)
                .IsRequired();

            Property(t => t.CodigoLojaLegado)
                .HasMaxLength(3)
                .IsRequired();

            Property(t => t.NomeLoja)
                .HasMaxLength(150)
                .IsRequired();

            Property(t => t.NomeReduzido)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
