using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BobsBurgerAPI_v2.Endpoints.Situacoes;

public class SituacaoDelete
{
    public static string Template => "/situacao/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, AppDbContext ctx)
    {
        var situacao = ctx.Situacoes.Where(s => s.Id == id).FirstOrDefault();

        if (situacao == null)
            return Results.NotFound();

        ctx.Situacoes.Remove(situacao);

        ctx.SaveChanges();

        return Results.Ok();
    }
}