using BobsBurgerAPI_v2.Endpoints.Pagamentos;
using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BobsBurgerAPI_v2.Endpoints.Situacoes;

public class PagamentoPut
{
    public static string Template => "/pagamento/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public record PagamentoResponse(int Id, string Nome, decimal Taxa, bool Ativo);
    public record PagamentoRequest(string Nome, decimal Taxa, bool Ativo);

    public static IResult Action([FromRoute] int id, PagamentoRequest pagamentoRequest, AppDbContext context)
    {
        var pagamento = context.Pagamentos.Where(s => s.Id == id).FirstOrDefault();

        if (pagamento == null)
            return Results.NotFound();

        pagamento.EditInfo(pagamentoRequest.Nome, pagamentoRequest.Taxa, pagamentoRequest.Ativo);

        //context.Situacoes.Add(situacao);
        context.SaveChanges();

        var response = new PagamentoResponse(pagamento.Id, pagamento.Nome, pagamento.Taxa, pagamento.Ativo);

        return Results.Ok(response);
    }
}