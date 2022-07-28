using BobsBurgerAPI_v2.Endpoints.Situacoes;
using BobsBurgerAPI_v2.Infra.Data;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<AppDbContext>(builder.Configuration["ConnectionString:Default"]);
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.UseHttpsRedirection();

// Situação
app.MapMethods(SituacaoPost.Template, SituacaoPost.Methods, SituacaoPost.Handle);

app.Run();