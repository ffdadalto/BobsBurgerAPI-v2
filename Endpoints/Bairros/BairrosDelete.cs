using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairrosDelete
{
    public static string Template => "/bairros";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromBody] int[] ids, AppDbContext context)
    {
        foreach (var id in ids)
        {
            var bairro = context.Bairros.Where(s => s.Id == id).FirstOrDefault();

            if (bairro == null)
                return Results.NotFound();

            context.Bairros.Remove(bairro);
        }
        context.SaveChanges();

        return Results.Ok();
    }
}