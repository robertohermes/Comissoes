using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;


namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class FilialMap : EntityTypeConfiguration<Filial>
    {
        public const string TableName = "DimFilial";
        public FilialMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.Id_Filial);

            // Properties
            Property(t => t.Id_Empresa)
                .IsRequired();

            Property(t => t.Id_Cidade)
                .IsRequired();

            Property(t => t.CodigoFilialAlternate)
                .HasMaxLength(2)
                .IsRequired();

            Property(t => t.NomeFilial)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
