using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class ControleAcessoMap : EntityTypeConfiguration<ControleAcesso>
    {
        public const string TableName = "COMIS_CONTROLE_ACESSO";
        public ControleAcessoMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.COLABORADORKEY);

            // Properties
            Property(t => t.COLABORADORKEY_PAI)
                .IsOptional();

            Property(t => t.CODIGOSECUNDARIO)
                .HasMaxLength(40)
                .IsRequired();

            Property(t => t.CODIGOEMPRESAALTERNATE)
                .HasMaxLength(2)
                .IsRequired();

            Property(t => t.CODIGOFILIALALTERNATE)
                .HasMaxLength(2)
                .IsRequired();

            Property(t => t.LOGIN)
                .HasMaxLength(255)
                .IsRequired();

            Property(t => t.ADMIN)
                .HasMaxLength(1)
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
