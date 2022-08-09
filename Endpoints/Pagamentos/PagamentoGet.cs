using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Pagamentos;


public class PagamentoGet
{
    public static string Template => "/pagamento/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public record PagamentoResponse(int Id, string Nome, decimal Taxa, bool Ativo);

    public static IResult Action([FromRoute] int id, AppDbContext context)
    {
        var pagamento = context.Pagamentos.Where(s => s.Id == id).FirstOrDefault();

        if (pagamento == null)
            return Results.NotFound();

        var response = new PagamentoResponse(
                pagamento.Id,
                pagamento.Nome,
                pagamento.Taxa,
                pagamento.Ativo);

        return Results.Ok(response);
    }
}