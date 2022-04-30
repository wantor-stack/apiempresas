using ApiEmpresas.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento ORM para a entidade Empresa
    /// </summary>
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        /// <summary>
        /// Método para fazer o mapeamento da entidade
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            //nome da tabela
            builder.ToTable("EMPRESA");

            //chave primaria
            builder.HasKey(e => e.IdEmpresa);

            //mapeamento dos campos da tabela
            builder.Property(e => e.IdEmpresa)
                .HasColumnName("IDEMPRESA");

            builder.Property(e => e.NomeFantasia)
                .HasColumnName("NOMEFANTASIA")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.RazaoSocial)
                .HasColumnName("RAZAOSOCIAL")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Cnpj)
                .HasColumnName("CNPJ")
                .HasMaxLength(20)
                .IsRequired();

            #region Mapeamento de Campos Únicos

            builder.HasIndex(e => e.Cnpj)
                .IsUnique();

            #endregion
        }
    }
}
