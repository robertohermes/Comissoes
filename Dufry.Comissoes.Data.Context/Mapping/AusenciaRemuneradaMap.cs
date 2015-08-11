using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class AusenciaRemuneradaMap : EntityTypeConfiguration<AusenciaRemunerada>
    {
        public const string TableName = "COMIS_AUSENCIA_REMUNERADA";
        public AusenciaRemuneradaMap()
        {
            ToTable(TableName);


            // Primary Key
            HasKey(t => t.ID_AUSENCIA_REMUNERADA);

            // Properties
            Property(t => t.COLABORADORKEY)
                .IsRequired();

            Property(t => t.DESC_AUSENCIA)
                .HasMaxLength(255)
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
