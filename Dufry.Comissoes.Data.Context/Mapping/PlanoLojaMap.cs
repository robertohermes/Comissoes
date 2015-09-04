using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class PlanoLojaMap : EntityTypeConfiguration<PlanoLoja>
    {
        public const string TableName = "COMIS_PLANO_LOJA";
        public PlanoLojaMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.ID_PLANO_LOJA);

            // Properties
            Property(t => t.ID_PLANO)
                .IsRequired();

            Property(t => t.CODIGOLOJAALTERNATE)
                .HasMaxLength(10)
                .IsRequired();

            Property(t => t.DT_INI)
                .IsRequired();

            Property(t => t.DT_FIM)
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
