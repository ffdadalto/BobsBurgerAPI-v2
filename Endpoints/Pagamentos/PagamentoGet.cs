using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Pagamentos;


public class PagamentoGet
{
    public static string Template => "/pagamento/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;    

    public static IResult Action([FromRoute] int id, AppDbContext ctx)
    {
        var pagamento = ctx.Pagamentos.Where(s => s.Id == id).FirstOrDefault();

        if (pagamento == null)
            return Results.NotFound();        

        return Results.Ok(pagamento);
    }
}