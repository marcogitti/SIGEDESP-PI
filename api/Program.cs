using api.Data;
using api.Repositorios;
using api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using api.Service.Interfaces;
using api.Services.Entities;
using AutoMapper;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using api.DTO.Mappings;

namespace Sigedesp
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DataBase");

            builder.Services.AddCors(o => o.AddPolicy("MyPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:3001")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    }));

            builder.Services.AddDbContext<SigedespDBContex>(options =>
                          options.UseNpgsql(connectionString));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            builder.Services.AddSingleton(mapper);
            builder.Services.AddTransient<ITipoDespesaRepositorio, TipoDespesaRepositorio>();
            builder.Services.AddTransient<ITipoDespesaService, TipoDespesaService>();
            builder.Services.AddTransient<ITipoInstituicaoRepositorio, TipoInstituicaoRepositorio>();
            builder.Services.AddTransient<ITipoInstituicaoService, TipoInstituicaoService>();
            builder.Services.AddTransient<IUnidadeMedidaRepositorio, UnidadeMedidaRepositorio>();
            builder.Services.AddTransient<IUnidadeMedidaService, UnidadeMedidaService>();
            builder.Services.AddTransient<IUnidadeConsumidoraRepositorio, UnidadeConsumidoraRepositorio>();
            builder.Services.AddTransient<IUnidadeConsumidoraService, UnidadeConsumidoraService>();
            builder.Services.AddTransient<ISecretariaRepositorio, SecretariaRepositorio>();
            builder.Services.AddTransient<ISecretariaService, SecretariaService>();
            builder.Services.AddTransient<IFornecedorRepositorio, FornecedorRepositorio>();
            builder.Services.AddTransient<IFornecedorService, FornecedorService>();
            builder.Services.AddTransient<IInstituicaoRepositorio, InstituicaoRepositorio>();
            builder.Services.AddTransient<IInstituicaoService, InstituicaoService>();
            builder.Services.AddTransient<IOrcamentoRepositorio, OrcamentoRepositorio>();
            builder.Services.AddTransient<IOrcamentoService, OrcamentoService>();
            builder.Services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddTransient<IUsuarioService, UsuarioService>();
            builder.Services.AddTransient<IDespesaRepositorio, DespesaRepositorio>();
            builder.Services.AddTransient<IDespesaService, DespesaService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseStaticFiles();

            app.UseCors("MyPolicy");

            app.UseRouting();

            app.Run();
        }
    }
}