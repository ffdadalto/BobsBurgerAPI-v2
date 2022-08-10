using BobsBurgerAPI_v2.Domain.Clientes;
using BobsBurgerAPI_v2.Domain.Enderecos;
using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Clientes;

public class ClientePost
{
    public static string Template => "/cliente";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;   

    public static IResult Action(Cliente req, AppDbContext ctx)
    {
        var cliente = new Cliente(
            req.Nome,
            req.Apelido,
            req.Telefone,
            req.Cep,
            req.Endereco,
            req.Numero,
            req.Ativo,
            req.BairroId);

        if (cliente == null)
            return Results.BadRequest();        

        ctx.Clientes.Add(cliente);
        ctx.SaveChanges();
        
        return Results.Created($"/cliente/{cliente.Id}", cliente);
    }
}
