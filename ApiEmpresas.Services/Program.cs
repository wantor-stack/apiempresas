using ApiEmpresas.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Configurando os controllers da aplica��o
builder.Services.AddControllers();

//Adicionando a configura��o do Swagger
SwaggerConfiguration.AddSwagger(builder);

//Adicionando a configura��o do EntityFramework
EntityFrameworkConfiguration.AddEntityFramework(builder);

//Adicionando a configura��o do AutoMapper
AutoMapperConfiguration.AddAutoMapper(builder);

//Adicionando a configura��o do JWT
JwtConfiguration.AddJwt(builder);

builder.Services.AddCors(s => s.AddPolicy("DefaultPolicy", builder => {
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

// Add services to the container.
var app = builder.Build();

// Habilitar as rotas e endpoints da API
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//Configurando o descritor da API
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPI");
});

app.UseCors("DefaultPolicy");

//Executar os servi�os
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

