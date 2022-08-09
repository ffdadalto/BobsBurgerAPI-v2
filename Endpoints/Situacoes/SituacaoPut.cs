using BobsBurgerAPI_v2.Domain.Pedidos;
using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BobsBurgerAPI_v2.Endpoints.Situacoes;

public class SituacaoPut
{
    public static string Template => "/situacao/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public record SituacaoResponse(int id, string nome, string cor, bool ativo);
    public record SituacaoRequest(string Nome, string Cor, bool Ativo);

    public static IResult Action([FromRoute] int id,  SituacaoRequest situacaoRequest, AppDbContext context)
    {
        var situacao = context.Situacoes.Where(s => s.Id == id).FirstOrDefault();

        if (situacao == null)
            return Results.NotFound();

        situacao.EditInfo(situacaoRequest.Nome, situacaoRequest.Cor,  situacaoRequest.Ativo);

        //context.Situacoes.Add(situacao);
        context.SaveChanges();

        var response = new SituacaoResponse(situacao.Id, situacao.Nome, situacao.Cor, situacao.Ativo);

        return Results.Ok(response);
    }
}