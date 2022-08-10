using BobsBurgerAPI_v2.Domain.Enderecos;
using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Clientes;


public class ClienteGetAll
{
    public static string Template => "/cliente";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(AppDbContext ctx)
    {
        var clientes = ctx.Clientes
            .Include(c => c.Bairro)
            .OrderByDescending(c => c.Id);

        return Results.Ok(clientes);
    }
}
