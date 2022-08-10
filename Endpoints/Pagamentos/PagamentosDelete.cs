using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BobsBurgerAPI_v2.Endpoints.Pagamentos;

public class PagamentosDelete
{
    public static string Template => "/pagamentos";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromBody] int[] ids, AppDbContext ctx)
    {
        foreach (var id in ids)
        {
            var pagamento = ctx.Pagamentos.Where(s => s.Id == id).FirstOrDefault();

            if (pagamento == null)
                return Results.NotFound();

            ctx.Pagamentos.Remove(pagamento);
        }
        ctx.SaveChanges();

        return Results.Ok();
    }
}