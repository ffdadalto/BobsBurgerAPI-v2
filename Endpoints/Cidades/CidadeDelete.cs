using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BobsBurgerAPI_v2.Endpoints.Cidades;

public class CidadeDelete
{
    public static string Template => "/cidade/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, AppDbContext ctx)
    {
        var cidade = ctx.Cidades.Where(s => s.Id == id).FirstOrDefault();

        if (cidade == null)
            return Results.NotFound();

        ctx.Cidades.Remove(cidade);

        ctx.SaveChanges();

        return Results.Ok();
    }
}