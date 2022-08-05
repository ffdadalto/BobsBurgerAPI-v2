using BobsBurgerAPI_v2.Domain.Enderecos;
using BobsBurgerAPI_v2.Endpoints.Cidades;
using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Cidades;

public class CidadePost
{
    public static string Template => "/cidade";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;
    

    public static IResult Action(CidadeRequest cidadeRequest, AppDbContext context)
    {
        var cidade = new Cidade(cidadeRequest.Nome, cidadeRequest.Ativo);

        if (cidade == null)
            return Results.BadRequest();


        context.Cidades.Add(cidade);
        context.SaveChanges();

        var response = new CidadeResponse(cidade.Id, cidade.Nome, cidade.Bairros.Count(), cidade.Ativo);

        return Results.Created($"/cidade/{cidade.Id}", response);        
    }
}
