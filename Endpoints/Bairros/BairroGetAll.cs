using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;


public class BairroGetAll
{
    public static string Template => "/bairro";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(AppDbContext ctx)
    {
        var bairros = ctx.Bairros
            .Include(b => b.Clientes)
            .OrderByDescending(b => b.Id);

        //return Results.Ok(bairros);

        return Results.Ok(bairros.Select(b => new
        {
            id = b.Id,
            nome = b.Nome,
            qtdClientes = b.Clientes.Count(),
            ativo = b.Ativo,
            cidadeId = b.CidadeId,
            cidade = ctx.Cidades.FirstOrDefault(c => c.Id == b.CidadeId)
        }));
    }
}
