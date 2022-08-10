using BobsBurgerAPI_v2.Domain.Enderecos;
using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Cidades;

public class CidadePost
{
    public static string Template => "/cidade";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;    

    public static IResult Action(Cidade req, AppDbContext ctx)
    {
        var cidade = new Cidade(req.Nome, req.Ativo);

        if (cidade == null)
            return Results.BadRequest();

        ctx.Cidades.Add(cidade);
        ctx.SaveChanges();        

        return Results.Created($"/cidade/{cidade.Id}", cidade);        
    }
}
