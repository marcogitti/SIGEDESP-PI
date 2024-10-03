using api.Data;
using api.Repositorios;
using api.Repositorios.Interfaces;
using api.Service.Interfaces;
using api.Services.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Sigedesp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // Ignora propriedades nulas
                    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

                });

            // Swagger/OpenAPI configuration
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Database connection
            var connectionString = builder.Configuration.GetConnectionString("DataBase");
            builder.Services.AddDbContext<SigedespDBContex>(options =>
                options.UseNpgsql(connectionString));

            // CORS policy
            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3000", "http://localhost:3001")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));

            // AutoMapper configuration
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile()); // Certifique-se de que MappingProfile esteja correto
            });
            IMapper mapper = mappingConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            // Repository and Service registrations
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
            app.UseCors("MyPolicy");
            app.UseAuthorization();
            app.MapControllers();
            app.UseStaticFiles();
            app.UseRouting();

            app.Run();
        }
    }
}
