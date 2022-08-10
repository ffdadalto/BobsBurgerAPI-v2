using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
namespace BobsBurgerAPI_v2.Endpoints.Cidades;

public class CidadesDelete
{
    public static string Template => "/cidades";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromBody] int[] ids, AppDbContext ctx)
    {
        foreach (var id in ids)
        {
            var cidade = ctx.Cidades.Where(s => s.Id == id).FirstOrDefault();

            if (cidade == null)
                return Results.NotFound();

            ctx.Cidades.Remove(cidade);
        }
        ctx.SaveChanges();

        return Results.Ok();
    }
}