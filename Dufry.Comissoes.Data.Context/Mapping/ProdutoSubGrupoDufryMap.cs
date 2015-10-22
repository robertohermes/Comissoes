using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class ProdutoSubGrupoDufryMap : EntityTypeConfiguration<ProdutoSubGrupoDufry>
    {
        public const string TableName = "DimProdutoSubGrupoDufry";

        public ProdutoSubGrupoDufryMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.Id_ProdutoSubGrupoDufry);

            // Properties
            Property(t => t.Id_ProdutoGrupoDufry)
                .IsRequired();

            Property(t => t.Id_ProdutoCategoria)
                .IsRequired();

            Property(t => t.CodigoProdutoSubGrupoDufryAlternate)
                .HasMaxLength(3)
                .IsRequired();

            Property(t => t.NomeProdutoSubGrupoDufry)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
