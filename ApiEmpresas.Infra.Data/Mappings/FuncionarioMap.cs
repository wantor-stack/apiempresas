﻿using ApiEmpresas.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Mappings
{
    //Classe de mapeamento para a entidade Funcionário
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        //método para mapear a entidade
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //nome da tabela
            builder.ToTable("FUNCIONARIO");

            //chave primária
            builder.HasKey(f => f.IdFuncionario);

            //mapeamento dos campos da entidade
            builder.Property(f => f.IdFuncionario)
                .HasColumnName("IDFUNCIONARIO")
                .IsRequired();

            builder.Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(f => f.Matricula)
                .HasColumnName("MATRICULA")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(f => f.DataAdmissao)
                .HasColumnName("DATAADMISSAO")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(f => f.IdEmpresa)
                .HasColumnName("IDEMPRESA")
                .IsRequired();

            #region Mapeamento de relacionamento

            builder.HasOne(f => f.Empresa)  //Funcionário tem 1 Empresa
                .WithMany(e => e.Funcionarios) //Empresa TEM MUITOS Funcionarios
                .HasForeignKey(f => f.IdEmpresa); //Chave Estrangeira

            #endregion

            #region Mapeamento de Campos Únicos

            builder.HasIndex(f => f.Cpf)
                .IsUnique();

            builder.HasIndex(f => f.Matricula)
                .IsUnique();

            #endregion
        }
    }
}

