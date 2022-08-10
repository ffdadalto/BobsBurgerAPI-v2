using BobsBurgerAPI_v2.Domain.Enderecos;
using BobsBurgerAPI_v2.Endpoints.Cidades;
using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace BobsBurgerAPI_v2.Endpoints.Cidades;

public class CidadePut
{
    public static string Template => "/cidade/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;    

    public static IResult Action([FromRoute] int id, Cidade req, AppDbContext ctx)
    {
        var cidade = ctx.Cidades.Where(s => s.Id == id).FirstOrDefault();

        if (cidade == null)
            return Results.NotFound();

        cidade.EditInfo(req.Nome, req.Ativo);
        
        ctx.SaveChanges();

        return Results.Ok(cidade);
    }
}