using CadastroUsuario.Data;
using CadastroUsuario.Data.Repository;
using CadastroUsuario.Factory;
using CadastroUsuario.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UsuarioServices, UsuarioServices>();
builder.Services.AddScoped<UsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<LogServices, LogServices>();
builder.Services.AddScoped<LogRepository, LogRepository>();
builder.Services.AddScoped<LogFactory, LogFactory>();
builder.Services.AddScoped<DataContext, DataContext>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.Run();
