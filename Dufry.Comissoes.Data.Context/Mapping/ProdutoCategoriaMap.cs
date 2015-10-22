using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class ProdutoCategoriaMap : EntityTypeConfiguration<ProdutoCategoria>
    {
        public const string TableName = "DimProdutoCategoria";

        public ProdutoCategoriaMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.Id_ProdutoCategoria);

            // Properties
            Property(t => t.CodigoProdutoCategoriaAlternate)
                .HasMaxLength(10)
                .IsRequired();

            Property(t => t.NomeProdutoCategoria)
                .HasMaxLength(120)
                .IsRequired();

        }
    }
}
