using BobsBurgerAPI_v2.Domain.Pedidos;
using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BobsBurgerAPI_v2.Endpoints.Situacoes;

public class SituacaoPut
{
    public static string Template => "/situacao/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id,  Situacao req, AppDbContext ctx)
    {
        var situacao = ctx.Situacoes.Where(s => s.Id == id).FirstOrDefault();

        if (situacao == null)
            return Results.NotFound();

        situacao.EditInfo(req.Nome, req.Cor, req.Ativo);

        
        ctx.SaveChanges();

        return Results.Ok(situacao);
    }
}