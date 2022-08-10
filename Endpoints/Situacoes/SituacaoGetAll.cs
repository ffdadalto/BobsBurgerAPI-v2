using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Situacoes;

public class SituacaoGetAll
{
    public static string Template => "/situacao";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;
    
    public static IResult Action(AppDbContext ctx)
    {
        var situacoes = ctx.Situacoes.OrderByDescending(s => s.Id);        

        return Results.Ok(situacoes);
    }
}
