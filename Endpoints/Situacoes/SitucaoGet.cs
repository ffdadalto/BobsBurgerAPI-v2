using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Situacoes;


public class SituacaoGet
{
    public static string Template => "/situacao/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, AppDbContext ctx)
    {
        var situacao = ctx.Situacoes.Where(s => s.Id == id).FirstOrDefault();

        if (situacao == null)
            return Results.NotFound();

        return Results.Ok(situacao);

        //return Results.Ok(
        //    new
        //    {
        //        id = situacao.Id,
        //        nome = situacao.Nome,
        //        cor = situacao.Cor
        //    });
    }
}