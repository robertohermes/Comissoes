﻿using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class DolarMedioMap : EntityTypeConfiguration<DolarMedio>
    {
        public const string TableName = "COMIS_DOLAR_MEDIO";
        public DolarMedioMap()
        {
            ToTable(TableName);
            
            // Primary Key
            HasKey(t => t.ID_DOLAR_MEDIO);

            // Properties
            Property(t => t.ID_PLANO)
                .IsRequired();

            Property(t => t.TIPO_TAXA)
                .HasMaxLength(1)
                .IsRequired();

            //Property(t => t.VALOR_DOLAR_MEDIO)
            //    .IsRequired();

            Property(t => t.DT_INI)
                .IsRequired();

            Property(t => t.DT_FIM)
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
