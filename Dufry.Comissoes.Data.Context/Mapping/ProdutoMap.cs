using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public const string TableName = "DimProduto";

        public ProdutoMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.Id_Produto);

            Property(t => t.Id_ProdutoTipo)
                .IsRequired();

            Property(t => t.Id_ProdutoSubGrupoDufry)
                .IsRequired();

            Property(t => t.Id_TipoBusiness)
                .IsRequired();

            Property(t => t.CodigoProdutoAlternate)
                .HasMaxLength(10)
                .IsRequired();

            Property(t => t.DescricaoProdutoNome)
                .HasMaxLength(250)
                .IsRequired();

            Property(t => t.DescricaoProdutoNomeIngles)
                .HasMaxLength(250)
                .IsRequired();

            Property(t => t.Cor)
                .HasMaxLength(15);

            Property(t => t.NCM)
                .HasMaxLength(20);

            Property(t => t.Nacional)
                .HasMaxLength(1);

            Property(t => t.MarcaLocal)
                .HasMaxLength(250);

            Property(t => t.LinhaLocal)
                .HasMaxLength(250);

            Property(t => t.MarcaGlobal)
                .HasMaxLength(250);

            Property(t => t.LinhaGlobal)
                .HasMaxLength(250);

            Property(t => t.Tamanho)
                .HasMaxLength(50);

            Property(t => t.Peso);

            Property(t => t.Modelo)
                .HasMaxLength(50);

            Property(t => t.StartDate);

            Property(t => t.EndDate);

            Property(t => t.Status)
                .HasMaxLength(1);
        }
    }
}
