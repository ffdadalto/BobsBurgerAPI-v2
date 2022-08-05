using BobsBurgerAPI_v2.Endpoints.Cidades;
using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Cidades;


public class CidadeGetAll
{
    public static string Template => "/cidade";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(AppDbContext context)
    {
        var cidades = context.Cidades.Include(c => c.Bairros).ToList();
        var response = cidades.OrderByDescending(s => s.Id)
            .Select(s => new CidadeResponse(
                s.Id,
                s.Nome,
                s.Bairros.Count(),
                s.Ativo));

        //var response = bairros.OrderByDescending(s => s.Id)
        //   .Select(s => new BairroResponseResumido(s.Id, s.Nome)

        //       );

        return Results.Ok(response);
    }
}
