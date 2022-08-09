using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Situacoes;


public class SituacaoGet
{
    public static string Template => "/situacao/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public record SituacaoResponse(int id, string nome, string cor, bool ativo);

    public static IResult Action([FromRoute] int id, AppDbContext context)
    {
        var situacao = context.Situacoes.Where(s => s.Id == id).FirstOrDefault();

        if (situacao == null)
            return Results.NotFound();

        var response = new SituacaoResponse(
                situacao.Id,
                situacao.Nome,
                situacao.Cor,
                situacao.Ativo);

        return Results.Ok(response);
    }
}