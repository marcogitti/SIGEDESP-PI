﻿using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.RG).IsRequired().HasMaxLength(12);
            builder.Property(x => x.Logradouro).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Numero).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(25);
            builder.Property(x => x.CEP).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Situacao).IsRequired();
            builder.Property(x => x.Matricula).IsRequired().HasMaxLength(100);
            builder.Property(x => x.TipoUsuario).IsRequired();

            // Inserções de teste
            builder.HasData(
                new UsuarioModel
                {
                    Id = 1,
                    CPF = "12345678901",
                    Nome = "João Silva",
                    RG = "123456789",
                    Logradouro = "Rua A",
                    Numero = "10",
                    Cidade = "Jales",
                    Bairro = "Centro",
                    Estado = "São Paulo",
                    CEP = "12345678",
                    Email = "joao.silva@gmail.com",
                    Senha = "senha123",
                    Situacao = Models.Enum.EnumSituacaoModel.ativo,
                    Matricula = "20240001",
                    TipoUsuario = Models.Enum.TipoUsuarioEnum.administrador
                },
                new UsuarioModel
                {
                    Id = 2,
                    CPF = "98765432100",
                    Nome = "Maria Souza",
                    RG = "987654321",
                    Logradouro = "Avenida B",
                    Numero = "20",
                    Cidade = "Jales",
                    Bairro = "Centro",
                    Estado = "São Paulo",
                    CEP = "87654321",
                    Email = "maria.souza@example.com",
                    Senha = "senha456",
                    Situacao = Models.Enum.EnumSituacaoModel.inativo,
                    Matricula = "20240002",
                    TipoUsuario = Models.Enum.TipoUsuarioEnum.funcionario
                },
                new UsuarioModel
                {
                    Id = 3,
                    CPF = "98785432100",
                    Nome = "Rafael Andrade",
                    RG = "787654321",
                    Logradouro = "Avenida C",
                    Numero = "30",
                    Cidade = "Jales",
                    Bairro = "Nova York",
                    Estado = "São Paulo",
                    CEP = "87654330",
                    Email = "rafael.andrade@gmail.com",
                    Senha = "senha789",
                    Situacao = Models.Enum.EnumSituacaoModel.ativo,
                    Matricula = "20240003",
                    TipoUsuario = Models.Enum.TipoUsuarioEnum.visitante
                }
            );
        }
    }
}
