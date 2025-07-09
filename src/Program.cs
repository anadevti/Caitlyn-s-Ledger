using CaitlynsLedgerAPI.Data;
using CaitlynsLedgerAPI.Infra.Authentication;
using Microsoft.EntityFrameworkCore;
using CaitlynsLedger.Domain.Interfaces;
using CaitlynsLedger.Infrastructure.Repositories;
using CaitlynsLedger.Application.Services;
using CaitlynsLedger.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados usando SQLite
builder.Services.AddDbContext<CaitlynsLedgerContext>(options =>
    options.UseSqlite("Data Source=CaitlynsLedger.db"));

// Adiciona suporte a sessão (importante para OAuth state)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
    options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
});

// Configuração de autenticação Google - usando a extensão
builder.Services.AddGoogleAuth(builder.Configuration);

// Adiciona serviços e controladores
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Registra repositórios
builder.Services.AddScoped<ISuspectRepository, SuspectRepository>();
builder.Services.AddScoped<ICaseRepository, CaseRepository>();
builder.Services.AddScoped<IClueRepository, ClueRepository>();

// Registra serviços
builder.Services.AddScoped<SuspectService>();
builder.Services.AddScoped<CaseService>();
builder.Services.AddScoped<ClueService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração de middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSession(); // Adiciona middleware de sessão antes da autenticação
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();