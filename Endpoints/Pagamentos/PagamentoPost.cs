using BobsBurgerAPI_v2.Domain.Pedidos;
using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Pagamentos;

public class PagamentoPost
{
    public static string Template => "/pagamento";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(Pagamento req, AppDbContext ctx)
    {
        var pagamento = new Pagamento(req.Nome, req.Taxa, req.Ativo);

        if (pagamento == null)
            return Results.BadRequest();


        ctx.Pagamentos.Add(pagamento);
        ctx.SaveChanges();

        return Results.Created($"/situacao/{pagamento.Id}", pagamento);
    }
}