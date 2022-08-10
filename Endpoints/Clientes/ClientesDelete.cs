using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
namespace BobsBurgerAPI_v2.Endpoints.Clientes;

public class ClientesDelete
{
    public static string Template => "/clientes";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromBody] int[] ids, AppDbContext ctx)
    {
        foreach (var id in ids)
        {
            var cliente = ctx.Clientes.Where(s => s.Id == id).FirstOrDefault();

            if (cliente == null)
                return Results.NotFound();

            ctx.Clientes.Remove(cliente);
        }
        ctx.SaveChanges();

        return Results.Ok();
    }
}