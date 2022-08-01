using BobsBurgerAPI_v2.Domain.Pedidos;
using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Situacoes;

public class SituacaoPost
{
    public static string Template => "/situacao";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(SituacaoRequest situacaoRequest, AppDbContext context)
    {
        var situacao = new Situacao(situacaoRequest.Nome);

        if (situacao == null)
            return Results.BadRequest();


        context.Situacoes.Add(situacao);
        context.SaveChanges();

        var response = new SituacaoResponse(situacao.Id, situacao.Nome, situacao.Ativo);

        return Results.Created($"/situacao/{response.Id}", response);
        //return Results.Ok("Funcionou!");
    }
}
