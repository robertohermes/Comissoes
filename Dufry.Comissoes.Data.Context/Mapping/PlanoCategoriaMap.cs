using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class PlanoCategoriaMap : EntityTypeConfiguration<PlanoCategoria>
    {
        public const string TableName = "COMIS_PLANO_CATEGORIA";
        public PlanoCategoriaMap()
        {
            ToTable(TableName);


            // Primary Key
            HasKey(t => new { t.ID_PLANO, t.ID_CATEGORIA_PERCENTUAL });

            // Properties
            Property(t => t.ORDEM_HIERARQUIA)
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
