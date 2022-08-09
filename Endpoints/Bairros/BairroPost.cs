using BobsBurgerAPI_v2.Domain.Enderecos;
using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairroPost
{
    public static string Template => "/bairro";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;


    public static IResult Action(BairroRequest bairroRequest, AppDbContext context)
    {
        var bairro = new Bairro(
            bairroRequest.Nome, 
            bairroRequest.CidadeId, 
            bairroRequest.Ativo);

        if (bairro == null)
            return Results.BadRequest();

        var cidade = context.Cidades
            .Where(s => s.Id == bairroRequest.CidadeId)
            .FirstOrDefault();

        if (cidade == null)
            return Results.BadRequest();

        bairro.Cidade = cidade; 

        context.Bairros.Add(bairro);
        context.SaveChanges();

        var response = new BairroResponse(
            bairro.Id, 
            bairro.Nome, 
            bairro.Clientes.Count(),
            bairro.Cidade.Id, 
            bairro.Cidade.Nome, 
            bairro.Ativo);

        return Results.Created($"/bairro/{bairro.Id}", response);
    }
}

