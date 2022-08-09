using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairroPut
{
    public static string Template => "/bairro/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, BairroRequest bairroRequest, AppDbContext context)
    {
        var bairro = context.Bairros
            .Include(b => b.Cidade)
            .Where(s => s.Id == id).FirstOrDefault();

        if (bairro == null)
            return Results.NotFound();

        bairro.EditInfo(bairroRequest.Nome, bairroRequest.CidadeId, bairroRequest.Ativo);
        bairro.Cidade = context.Cidades.Where(c => c.Id == bairroRequest.CidadeId).FirstOrDefault();

        //context.Situacoes.Add(situacao);        
        context.SaveChanges();

        var response = new BairroResponse(
            bairro.Id,
            bairro.Nome,
            bairro.Clientes.Count(),
            bairro.Cidade.Id,
            bairro.Cidade.Nome,
            bairro.Ativo);

        return Results.Ok(response);
    }
}