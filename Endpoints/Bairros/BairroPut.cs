using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairroPut
{
    public static string Template => "/bairro/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;


    public record BairroResponse(int Id, string Nome, int CidadeId, bool Ativo);
    public record BairroRequest(string Nome, int CidadeId, bool Ativo);

    public static IResult Action([FromRoute] int id, BairroRequest bairroRequest, AppDbContext context)
    {
        var bairro = context.Bairros            
            .Where(s => s.Id == id).FirstOrDefault();

        if (bairro == null)
            return Results.NotFound();

        bairro.EditInfo(
            bairroRequest.Nome, 
            bairroRequest.CidadeId, 
            bairroRequest.Ativo);
        

        //context.Situacoes.Add(situacao);        
        context.SaveChanges();

        var response = new BairroResponse(
            bairro.Id,
            bairro.Nome,            
            bairro.CidadeId,            
            bairro.Ativo);

        return Results.Ok(response);
    }
}