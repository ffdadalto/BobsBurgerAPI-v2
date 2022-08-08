using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Cidades;


public class CidadeGet
{
    public static string Template => "/cidade/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, AppDbContext context)
    {
        var cidade = context.Cidades.Include(c => c.Bairros).Where(s => s.Id == id).FirstOrDefault();

        if (cidade == null)
            return Results.NotFound();

        var response = new CidadeResponse(
                cidade.Id,
                cidade.Nome,
                cidade.Bairros.Count(),
                cidade.Ativo);

        return Results.Ok(response);
    }
}
