using BobsBurgerAPI_v2.Endpoints.Bairros;
using BobsBurgerAPI_v2.Endpoints.Cidades;
using BobsBurgerAPI_v2.Endpoints.Pagamentos;
using BobsBurgerAPI_v2.Endpoints.Situacoes;
using BobsBurgerAPI_v2.Infra.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<AppDbContext>(builder.Configuration["ConnectionString:Default"]);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



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
app.MapMethods(SituacaoGet.Template, SituacaoGet.Methods, SituacaoGet.Handle);
app.MapMethods(SituacaoGetAll.Template, SituacaoGetAll.Methods, SituacaoGetAll.Handle);
app.MapMethods(SituacaoPost.Template, SituacaoPost.Methods, SituacaoPost.Handle);
app.MapMethods(SituacaoPut.Template, SituacaoPut.Methods, SituacaoPut.Handle);
app.MapMethods(SituacaoDelete.Template, SituacaoDelete.Methods, SituacaoDelete.Handle);
app.MapMethods(SituacoesDelete.Template, SituacoesDelete.Methods, SituacoesDelete.Handle);

// Bairro
app.MapMethods(BairroGet.Template, BairroGet.Methods, BairroGet.Handle);
app.MapMethods(BairroGetAll.Template, BairroGetAll.Methods, BairroGetAll.Handle);
app.MapMethods(BairroPost.Template, BairroPost.Methods, BairroPost.Handle);
app.MapMethods(BairroPut.Template, BairroPut.Methods, BairroPut.Handle);
app.MapMethods(BairroDelete.Template, BairroDelete.Methods, BairroDelete.Handle);
app.MapMethods(BairrosDelete.Template, BairrosDelete.Methods, BairrosDelete.Handle);

// Cidade
app.MapMethods(CidadeGet.Template, CidadeGet.Methods, CidadeGet.Handle);
app.MapMethods(CidadeGetAll.Template, CidadeGetAll.Methods, CidadeGetAll.Handle);
app.MapMethods(CidadePost.Template, CidadePost.Methods, CidadePost.Handle);
app.MapMethods(CidadePut.Template, CidadePut.Methods, CidadePut.Handle);
app.MapMethods(CidadeDelete.Template, CidadeDelete.Methods, CidadeDelete.Handle);
app.MapMethods(CidadesDelete.Template, CidadesDelete.Methods, CidadesDelete.Handle);

// Pagamento
app.MapMethods(PagamentoGet.Template, PagamentoGet.Methods, PagamentoGet.Handle);
app.MapMethods(PagamentoGetAll.Template, PagamentoGetAll.Methods, PagamentoGetAll.Handle);
app.MapMethods(PagamentoPost.Template, PagamentoPost.Methods, PagamentoPost.Handle);
app.MapMethods(PagamentoPut.Template, PagamentoPut.Methods, PagamentoPut.Handle);
app.MapMethods(PagamentoDelete.Template, PagamentoDelete.Methods, PagamentoDelete.Handle);
app.MapMethods(PagamentosDelete.Template, PagamentosDelete.Methods, PagamentosDelete.Handle);

app.Run();