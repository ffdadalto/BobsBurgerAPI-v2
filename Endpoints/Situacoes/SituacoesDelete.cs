using BobsBurgerAPI_v2.Domain.Pedidos;
using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BobsBurgerAPI_v2.Endpoints.Situacoes;

public class SituacoesDelete
{
    public static string Template => "/situacoes";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromBody] int[] ids, AppDbContext context)
    {
        foreach (var id in ids)
        {
            var situacao = context.Situacoes.Where(s => s.Id == id).FirstOrDefault();

            if (situacao == null)
                return Results.NotFound();

            context.Situacoes.Remove(situacao);
        }
        context.SaveChanges();

        return Results.Ok();
    }
}