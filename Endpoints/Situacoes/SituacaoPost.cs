using BobsBurgerAPI_v2.Domain.Pedidos;
using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Situacoes;

public class SituacaoPost
{
    public static string Template => "/situacao";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;    

    public static IResult Action(Situacao req, AppDbContext ctx)
    {
        var situacao = new Situacao(
            req.Nome,
            req.Cor,
            req.Ativo);

        if (situacao == null)
            return Results.BadRequest();

        ctx.Situacoes.Add(situacao);
        ctx.SaveChanges();        

        return Results.Created($"/situacao/{situacao.Id}", situacao);        
    }
}
