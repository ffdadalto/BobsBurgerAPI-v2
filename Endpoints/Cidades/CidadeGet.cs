using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Cidades;


public class CidadeGet
{
    public static string Template => "/cidade/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, AppDbContext ctx)
    {
        var cidade = ctx.Cidades
            .Include(c => c.Bairros)
            .Where(s => s.Id == id)
            .FirstOrDefault();

        if (cidade == null)
            return Results.NotFound();        

        return Results.Ok(cidade);
    }
}
