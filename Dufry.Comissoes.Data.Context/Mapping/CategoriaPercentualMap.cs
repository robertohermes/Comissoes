using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class CategoriaPercentualMap : EntityTypeConfiguration<CategoriaPercentual>
    {
        public const string TableName = "COMIS_CATEGORIA_PERCENTUAL";
        public CategoriaPercentualMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.ID_CATEGORIA_PERCENTUAL);

            // Properties
            Property(t => t.ID_CATEGORIA)
                .IsRequired();

            Property(t => t.ATRIBUTO)
                .HasMaxLength(255)
                .IsRequired();

            Property(t => t.CODIGOLOJAALTERNATE)
                .IsRequired();

            Property(t => t.PERCENTUAL)
                .IsRequired();

            Property(t => t.STATUS)
                .HasMaxLength(1)
                .IsRequired();

            Property(t => t.CREATED_DATETIME)
                .IsRequired();

            Property(t => t.CREATED_USERNAME)
                .HasMaxLength(255)
                .IsRequired();

            Property(t => t.LAST_MODIFY_DATE)
                .IsRequired();

            Property(t => t.LAST_MODIFY_USERNAME)
                .HasMaxLength(255)
                .IsRequired();


            //Ignore(t => t.ValidationResult);
        }
    }
}
