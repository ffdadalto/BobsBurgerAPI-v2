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
            policy.WithOrigins() // note the port is included 
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("MyAllowedOrigins");


// Situação
app.MapMethods(SituacaoPost.Template, SituacaoPost.Methods, SituacaoPost.Handle);
app.MapMethods(SituacaoGetAll.Template, SituacaoGetAll.Methods, SituacaoGetAll.Handle);
app.MapMethods(SituacaoPut.Template, SituacaoPut.Methods, SituacaoPut.Handle);
app.MapMethods(SituacaoDelete.Template, SituacaoDelete.Methods, SituacaoDelete.Handle);
app.MapMethods(SituacoesDelete.Template, SituacoesDelete.Methods, SituacoesDelete.Handle);

app.Run();