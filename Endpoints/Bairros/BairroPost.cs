using BobsBurgerAPI_v2.Domain.Enderecos;
using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairroPost
{
    public static string Template => "/bairro";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public record BairroResponse(int Id, string Nome, int CidadeId, bool Ativo);
    public record BairroRequest(string Nome, int CidadeId, bool Ativo);


    public static IResult Action(BairroRequest bairroRequest, AppDbContext context)
    {
        var bairro = new Bairro(
            bairroRequest.Nome, 
            bairroRequest.CidadeId, 
            bairroRequest.Ativo);

        if (bairro == null)
            return Results.BadRequest();        

        context.Bairros.Add(bairro);
        context.SaveChanges();

        var response = new BairroResponse(
            bairro.Id, 
            bairro.Nome,             
            bairro.CidadeId,             
            bairro.Ativo);

        return Results.Created($"/bairro/{bairro.Id}", response);
    }
}

