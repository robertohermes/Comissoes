using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public const string TableName = "COMIS_CATEGORIA";
        public CategoriaMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.ID_CATEGORIA);

            // Properties
            Property(t => t.DESC_CATEGORIA)
                .HasMaxLength(255)
                .IsRequired();

            Property(t => t.TAB_ORIGEM)
                .HasMaxLength(255)
                .IsRequired();

            Property(t => t.COL_ORIGEM)
                .HasMaxLength(255)
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
