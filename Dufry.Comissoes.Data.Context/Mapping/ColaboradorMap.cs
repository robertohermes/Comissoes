﻿using System.Data.Entity.ModelConfiguration;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.Data.Context.Mapping
{
    public class ColaboradorMap : EntityTypeConfiguration<Colaborador>
    {
        public const string TableName = "DimColaborador";

        public ColaboradorMap()
        {
            ToTable(TableName);

            // Primary Key
            HasKey(t => t.Id_Colaborador);

            // Properties
            Property(t => t.Id_Loja)
                .IsRequired();

            Property(t => t.Id_Cargo)
                .IsRequired();

            Property(t => t.CodigoSecundario)
                .HasMaxLength(4)
                .IsRequired();

            Property(t => t.NomeCompleto)
                .HasMaxLength(40)
                .IsRequired();

            Property(t => t.DataAdmissao)
                .IsOptional();

            Property(t => t.DataNascimento)
                .IsOptional();

            Property(t => t.Email)
                .HasMaxLength(50)
                .IsOptional();

            Property(t => t.Genero)
                .HasMaxLength(1)
                .IsOptional();

            Property(t => t.Comissao)
                .IsOptional();

        }
    }
}
