using NewMTest.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMTest.Data.Context.EntityConfig
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Pessoa> entity)
        {
            entity.HasKey(o => o.PessoaId);

            entity.Property(t => t.Nome)
                .IsRequired();

            entity.Property(t => t.Endereco)
                .IsRequired();

            entity.Property(t => t.Observacao)
                .HasMaxLength(300);

            entity.Property(t => t.DataInclusao)
                .IsRequired()
                .HasColumnType("Date")
                .HasDefaultValueSql("GetDate()");

            entity.Property(t => t.Ativado)
                .IsRequired()
                .HasDefaultValue(true);

            entity.Property(d => d.Celular)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(d => d.Email)
                .IsRequired();

            entity.Property(d => d.Cpf)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasData(
                new Pessoa
                {
                    PessoaId = 1,
                    Nome = "Raphael dos Santos Garbina",
                    DataNascimento = new DateTime(1994, 05, 03),
                    Cpf= "70258976047",
                    Celular="17981515290",
                    Email="raphael@hotmail.com",
                    Endereco="rua matias de albuquerque 1371 jardim maria lucia",
                    Observacao="Desenvolvedor"
                });
        }
    }

}
