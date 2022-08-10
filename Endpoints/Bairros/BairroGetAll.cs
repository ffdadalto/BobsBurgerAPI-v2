using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;


public class BairroGetAll
{
    public static string Template => "/bairro";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(AppDbContext ctx)
    {
        var bairros = ctx.Bairros.OrderByDescending(b => b.Id);                      

        return Results.Ok(bairros);
    }
}
