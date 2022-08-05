using BobsBurgerAPI_v2.Endpoints.Bairros;
using BobsBurgerAPI_v2.Endpoints.Cidades;
using BobsBurgerAPI_v2.Endpoints.Situacoes;
using BobsBurgerAPI_v2.Infra.Data;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<AppDbContext>(builder.Configuration["ConnectionString:Default"]);
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            //policy.WithOrigins("http://192.168.1.112:5173/") // note the port is included 
            policy.WithOrigins()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("MyAllowedOrigins");


// Situação
app.MapMethods(SituacaoGetAll.Template, SituacaoGetAll.Methods, SituacaoGetAll.Handle);
app.MapMethods(SituacaoPost.Template, SituacaoPost.Methods, SituacaoPost.Handle);
app.MapMethods(SituacaoPut.Template, SituacaoPut.Methods, SituacaoPut.Handle);
app.MapMethods(SituacaoDelete.Template, SituacaoDelete.Methods, SituacaoDelete.Handle);
app.MapMethods(SituacoesDelete.Template, SituacoesDelete.Methods, SituacoesDelete.Handle);

// Bairro
app.MapMethods(BairroGetAll.Template, BairroGetAll.Methods, BairroGetAll.Handle);

// Cidade
app.MapMethods(CidadeGetAll.Template, CidadeGetAll.Methods, CidadeGetAll.Handle);
app.MapMethods(CidadePost.Template, CidadePost.Methods, CidadePost.Handle);
app.MapMethods(CidadePut.Template, CidadePut.Methods, CidadePut.Handle);
app.MapMethods(CidadeDelete.Template, CidadeDelete.Methods, CidadeDelete.Handle);
app.MapMethods(CidadesDelete.Template, CidadesDelete.Methods, CidadesDelete.Handle);

app.Run();