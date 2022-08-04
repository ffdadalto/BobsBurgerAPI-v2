using BobsBurgerAPI_v2.Domain.Enderecos;
using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;


public class BairroGetAll
{
    public static string Template => "/bairro";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public record BairroResponse(int id, string nome, int cidadeId, string nomeCidade, bool ativo);
    public record BairroResponseResumido(int id, string nome);

    public static IResult Action(AppDbContext context)
    {
        var bairros = context.Bairros.Include(b => b.Cidade).ToList();
        //var response = bairros.OrderByDescending(s => s.Id)
        //    .Select(s => new BairroResponse(
        //        s.Id,
        //        s.Nome,
        //        s.CidadeId,
        //        s.Cidade.Nome,
        //        s.Ativo));

        var response = bairros.OrderByDescending(s => s.Id)
           .Select(s => new BairroResponseResumido(s.Id, s.Nome)

               );

        return Results.Ok(response);
    }
}
