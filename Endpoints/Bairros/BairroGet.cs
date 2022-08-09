using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairroGet
{
    public static string Template => "/bairro/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public record BairroResponse(int Id, string Nome, int CidadeId, bool Ativo);

    public static IResult Action([FromRoute] int id, AppDbContext context)
    {
        var bairro = context.Bairros                     
            .Where(s => s.Id == id).FirstOrDefault();

        if (bairro == null)
            return Results.NotFound();

        var response = new BairroResponse(
            bairro.Id,
            bairro.Nome,            
            bairro.CidadeId,            
            bairro.Ativo);

        return Results.Ok(response);
    }
}