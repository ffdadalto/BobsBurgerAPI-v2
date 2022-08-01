using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Situacoes;

public class SituacaoGetAll
{
    public static string Template => "/situacao";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(AppDbContext context)
    {
        var situacoes = context.Situacoes.ToList();
        var response = situacoes.OrderByDescending(s => s.Id)
            .Select(s => new SituacaoResponse(s.Id, s.Nome, s.Cor, s.Ativo));

        return Results.Ok(response);
    }
}
