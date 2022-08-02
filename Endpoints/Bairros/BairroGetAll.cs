using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairroGetAll
{
    public static string Template => "/bairro";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(AppDbContext context)
    {
        var bairros = context.Bairros.ToList();
        var response = bairros.OrderByDescending(s => s.Id)
            .Select(s => new BairroResponse(s.Id, s.Nome, s.CidadeId, s.Ativo));

        return Results.Ok(response);
    }
}
