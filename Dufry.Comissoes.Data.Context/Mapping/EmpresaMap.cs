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

            Property(t => t.Id_Pais)
                .IsRequired();

            Property(t => t.CodigoEmpresaAlternate)
                .IsRequired();

            Property(t => t.NomeEmpresa)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
