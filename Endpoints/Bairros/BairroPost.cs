using BobsBurgerAPI_v2.Domain.Enderecos;
using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairroPost
{
    public static string Template => "/bairro";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(Bairro req, AppDbContext ctx)
    {
        var bairro = new Bairro(
            req.Nome, 
            req.CidadeId, 
            req.Ativo);

        if (bairro == null)
            return Results.BadRequest();        

        ctx.Bairros.Add(bairro);
        ctx.SaveChanges();

        return Results.Created($"/bairro/{bairro.Id}", bairro);
    }
}

