using BobsBurgerAPI_v2.Endpoints.Cidades;
using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Cidades;


public class CidadeGetAll
{
    public static string Template => "/cidade";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;
    
    public static IResult Action(AppDbContext context)
    {
        var cidades = context.Cidades   
            .Include(c => c.Bairros)
            .OrderByDescending(c => c.Id);        

        return Results.Ok(cidades.Select( c => new
        {
            id = c.Id,
            nome = c.Nome,
            qtdBairros = c.Bairros.Count(),
            ativo = c.Ativo,
            bairros = c.Bairros
        }));
    }
}
