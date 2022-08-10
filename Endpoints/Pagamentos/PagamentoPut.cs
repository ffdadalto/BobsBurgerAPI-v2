using BobsBurgerAPI_v2.Domain.Pedidos;
using BobsBurgerAPI_v2.Endpoints.Pagamentos;
using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BobsBurgerAPI_v2.Endpoints.Situacoes;

public class PagamentoPut
{
    public static string Template => "/pagamento/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;    

    public static IResult Action([FromRoute] int id, Pagamento? req, AppDbContext ctx)
    {
        var pagamento = ctx.Pagamentos.Where(s => s.Id == id).FirstOrDefault();

        if (pagamento == null)
            return Results.NotFound();

        pagamento.EditInfo(req.Nome, req.Taxa, req.Ativo);
        
        ctx.SaveChanges();        

        return Results.Ok(pagamento);
    }
}