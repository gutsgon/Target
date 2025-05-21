using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Target.Data;
using Target.Exceptions;
using Target.Middlewares;
using Target.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os controllers da API
builder.Services.AddControllers().AddXmlSerializerFormatters();

// Adicona os Services da API
builder.Services.AddApplicationServices();

// Adiciona as variáveis de ambiente
DotNetEnv.Env.Load();
var secret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? throw new BusinessException("JWT_SECRET não encontrado");

// Adiciona a autenticação JWT
var key = System.Text.Encoding.UTF8.GetBytes(secret);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Permitido apenas para desenvolvimento, não usar em produção !!!
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
        ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
        IssuerSigningKey = new SymmetricSecurityKey(key), ClockSkew = TimeSpan.Zero
    };
});

// Adiciona o AutoMapper
builder.Services.AddAutoMapper(typeof(Target.Config.mapper.MapperConfig));

// Adiciona a conexão com o banco de dados
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Adiciona o Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    { Title = "Target API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Digite 'Bearer {seu_token}' no campo abaixo.",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

});

// Adiciona as Rotas
builder.Services.AddEndpointsApiExplorer();

// Inicialização do app
var app = builder.Build();

// Adiciona o middleware de tratamento de excessões
app.UseMiddleware<ExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Conexões HTTPS
//app.UseHttpsRedirection();

// Adiciona a autenticação a aplicação
app.UseAuthentication();

// Adiciona a autorização a aplicação
app.UseAuthorization();

// Adiciona os middlewares e controllers
app.MapControllers();

// Sobe a aplicação
app.Run();
