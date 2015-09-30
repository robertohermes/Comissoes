using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class ConfiguracaoMap : EntityTypeConfiguration<Configuracao>
    {
        public const string TableName = "COMIS_CONFIGURACAO";
        public ConfiguracaoMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.ID_CONFIGURACAO);

            // Properties
            Property(t => t.DESC_CHAVE)
                .HasMaxLength(255)
                .IsRequired();

            Property(t => t.DESC_VALOR)
                .HasMaxLength(255)
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
        }
    }
}
