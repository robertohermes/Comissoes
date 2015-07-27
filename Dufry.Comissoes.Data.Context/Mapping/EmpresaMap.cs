using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public const string TableName = "DimEmpresa";

        public EmpresaMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.Id_Empresa);

            // Properties
            Property(t => t.Id_TipoNegocio)
                .IsRequired();

            Property(t => t.Id_Pais)
                .IsRequired();

            Property(t => t.Id_TipoRegimeAduaneiro)
                .IsRequired();

            Property(t => t.CodigoEmpresaAlternate)
                .HasMaxLength(2)
                .IsRequired();

            Property(t => t.NomeEmpresa)
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.NomeReduzido)
                .HasMaxLength(11)
                .IsOptional();
        }
    }
}
