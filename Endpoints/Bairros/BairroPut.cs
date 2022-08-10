using BobsBurgerAPI_v2.Domain.Enderecos;
using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairroPut
{
    public static string Template => "/bairro/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, Bairro req, AppDbContext ctx)
    {
        var bairro = ctx.Bairros            
            .Where(s => s.Id == id).FirstOrDefault();

        if (bairro == null)
            return Results.NotFound();

        bairro.EditInfo(
            req.Nome, 
            req.CidadeId, 
            req.Ativo);
        

        //ctx.Situacoes.Add(situacao);        
        ctx.SaveChanges();

        return Results.Ok(bairro);
    }
}