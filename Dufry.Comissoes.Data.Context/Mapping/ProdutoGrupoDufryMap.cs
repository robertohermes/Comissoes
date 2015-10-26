using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class ProdutoGrupoDufryMap : EntityTypeConfiguration<ProdutoGrupoDufry>
    {
        public const string TableName = "DimProdutoGrupoDufry";

        public ProdutoGrupoDufryMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.Id_ProdutoGrupoDufry);

            // Properties
            Property(t => t.Id_ProdutoCategoria)
                .IsRequired();

            Property(t => t.CodigoProdutoGrupoDufryAlternate)
                .HasMaxLength(10)
                .IsRequired();

            Property(t => t.NomeProdutoGrupoDufry)
                .HasMaxLength(120)
                .IsRequired();
        }
    }
}
