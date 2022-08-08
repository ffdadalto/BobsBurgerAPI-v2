using BobsBurgerAPI_v2.Domain.Pedidos;
using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Pagamentos;

public class PagamentoPost
{
    public static string Template => "/pagamento";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(PagamentoRequest pagamentoRequest, AppDbContext context)
    {
        var pagamento = new Pagamento(pagamentoRequest.Nome, pagamentoRequest.Taxa, pagamentoRequest.Ativo);

        if (pagamento == null)
            return Results.BadRequest();


        context.Pagamentos.Add(pagamento);
        context.SaveChanges();

        var response = new PagamentoResponse(pagamento.Id, pagamento.Nome, pagamento.Taxa, pagamento.Ativo);

        return Results.Created($"/situacao/{response.Id}", response);
    }
}