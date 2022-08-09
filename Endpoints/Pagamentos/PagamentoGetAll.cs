using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Pagamentos;

public class PagamentoGetAll
{
    public static string Template => "/pagamento";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public record PagamentoResponse(int Id, string Nome, decimal Taxa, bool Ativo);

    public static IResult Action(AppDbContext context)
    {
        var pagamentos = context.Pagamentos.ToList();
        var response = pagamentos.OrderByDescending(s => s.Id)
            .Select(s => new PagamentoResponse(s.Id, s.Nome, s.Taxa, s.Ativo));

        return Results.Ok(response);
    }
}
