using api.Data;
using api.Repositorios.Interfaces;
using api.Repositorios;
using api.Service.Interfaces;
using api.Services.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using api.Authentication;
using Microsoft.OpenApi.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            });

        // Swagger/OpenAPI configuration
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "SIGEDESP API",
                Version = "v1"
            });

            // Configuração do esquema de segurança para JWT
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Insira o token JWT no formato: Bearer {seu token}"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });

        // Configuração do banco de dados
        var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
                               ?? builder.Configuration.GetConnectionString("DataBase");

        builder.Services.AddDbContext<SigedespDBContex>(options =>
            options.UseNpgsql(connectionString));

        // Configuração de CORS
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
            mc.AddProfile(new MappingProfile());
        });
        IMapper mapper = mappingConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);

        // Configuração da autenticação JWT
        var key = Encoding.ASCII.GetBytes(builder.Configuration["JWT:Secret"]);
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // Habilite para produção
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

        // Serviços e repositórios
        builder.Services.AddScoped<IDespesaRepositorio, DespesaRepositorio>();
        builder.Services.AddScoped<IDespesaService, DespesaService>();

        builder.Services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
        builder.Services.AddScoped<IFornecedorService, FornecedorService>();

        builder.Services.AddScoped<IInstituicaoRepositorio, InstituicaoRepositorio>();
        builder.Services.AddScoped<IInstituicaoService, InstituicaoService>();

        builder.Services.AddScoped<IOrcamentoRepositorio, OrcamentoRepositorio>();
        builder.Services.AddScoped<IOrcamentoService, OrcamentoService>();

        builder.Services.AddScoped<ISecretariaRepositorio, SecretariaRepositorio>();
        builder.Services.AddScoped<ISecretariaService, SecretariaService>();

        builder.Services.AddScoped<ITipoDespesaRepositorio, TipoDespesaRepositorio>();
        builder.Services.AddScoped<ITipoDespesaService, TipoDespesaService>();

        builder.Services.AddScoped<ITipoInstituicaoRepositorio, TipoInstituicaoRepositorio>();
        builder.Services.AddScoped<ITipoInstituicaoService, TipoInstituicaoService>();

        builder.Services.AddScoped<IUnidadeConsumidoraRepositorio, UnidadeConsumidoraRepositorio>();
        builder.Services.AddScoped<IUnidadeConsumidoraService, UnidadeConsumidoraService>();

        builder.Services.AddScoped<IUnidadeMedidaRepositorio, UnidadeMedidaRepositorio>();
        builder.Services.AddScoped<IUnidadeMedidaService, UnidadeMedidaService>();

        builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        builder.Services.AddScoped<IUsuarioService, UsuarioService>();

        var app = builder.Build();

        // Configuração do pipeline HTTP
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("MyPolicy");
        app.UseAuthentication(); // Adicionando autenticação
        app.UseAuthorization();  // Adicionando autorização
        app.MapControllers();

        app.Run();
    }
}
