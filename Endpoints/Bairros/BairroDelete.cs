using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairroDelete
{
    public static string Template => "/bairro/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, AppDbContext ctx)
    {
        var bairro = ctx.Bairros.Where(s => s.Id == id).FirstOrDefault();

        if (bairro == null)
            return Results.NotFound();

        ctx.Bairros.Remove(bairro);

        ctx.SaveChanges();

        return Results.Ok();
    }
}

