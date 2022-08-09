using BobsBurgerAPI_v2.Endpoints.Cidades;
using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BobsBurgerAPI_v2.Endpoints.Cidades;

public class CidadePut
{
    public static string Template => "/cidade/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public record CidadeResponse(int Id, string Nome, bool Ativo);

    public record CidadeRequest(string Nome, bool Ativo);

    public static IResult Action([FromRoute] int id, CidadeRequest cidadeRequest, AppDbContext context)
    {
        var cidade = context.Cidades.Where(s => s.Id == id).FirstOrDefault();

        if (cidade == null)
            return Results.NotFound();

        cidade.EditInfo(cidadeRequest.Nome, cidadeRequest.Ativo);
        
        context.SaveChanges();

        var response = new CidadeResponse(
            cidade.Id, 
            cidade.Nome,             
            cidade.Ativo);

        return Results.Ok(response);
    }
}