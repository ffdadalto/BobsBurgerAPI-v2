using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BobsBurgerAPI_v2.Endpoints.Clientes;

public class ClienteDelete
{
    public static string Template => "/cliente/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, AppDbContext context)
    {
        var cliente = context.Clientes.Where(s => s.Id == id).FirstOrDefault();

        if (cliente == null)
            return Results.NotFound();

        context.Clientes.Remove(cliente);

        context.SaveChanges();

        return Results.Ok();
    }
}