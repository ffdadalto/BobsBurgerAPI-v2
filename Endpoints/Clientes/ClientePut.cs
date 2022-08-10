using BobsBurgerAPI_v2.Domain.Clientes;
using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Clientes;

public class ClientePut
{
    public static string Template => "/cliente/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;   

    public static IResult Action([FromRoute] int id, Cliente req, AppDbContext ctx)
    {
        var cliente = ctx.Clientes            
            .Where(s => s.Id == id).FirstOrDefault();

        if (cliente == null)
            return Results.NotFound();

        cliente.EditInfo(
            req.Nome, 
            req.Apelido,
            req.Telefone,
            req.Cep,
            req.Endereco,
            req.Numero,
            req.BairroId,
            req.Ativo);        
                
        ctx.SaveChanges();       

        return Results.Ok(cliente);
    }
}