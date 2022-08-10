using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairroGet
{
    public static string Template => "/bairro/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, AppDbContext ctx)
    {
        var bairro = ctx.Bairros                     
            .Where(s => s.Id == id).FirstOrDefault();

        if (bairro == null)
            return Results.NotFound();

        return Results.Ok(bairro);
    }
}