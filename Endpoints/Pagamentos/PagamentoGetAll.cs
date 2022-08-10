using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Pagamentos;

public class PagamentoGetAll
{
    public static string Template => "/pagamento";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;    

    public static IResult Action(AppDbContext ctx)
    {
        var pagamentos = ctx.Pagamentos.OrderByDescending(p => p.Id);        

        return Results.Ok(pagamentos);
    }
}
