using BobsBurgerAPI_v2.Domain.Clientes;
using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Clientes;

public class ClientePost
{
    public static string Template => "/cliente";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;


    public static IResult Action(ClienteRequest clienteRequest, AppDbContext context)
    {
        var cliente = new Cliente(
            clienteRequest.Nome,
            clienteRequest.Apelido,
            clienteRequest.Telefone,
            clienteRequest.Cep,
            clienteRequest.Endereco,
            clienteRequest.Numero,
            clienteRequest.BairroId,
            clienteRequest.Ativo);

        if (cliente == null)
            return Results.BadRequest();

        var bairro = context.Bairros.Where(s => s.Id == clienteRequest.BairroId).FirstOrDefault();

        if (bairro == null)
            return Results.BadRequest();

        cliente.Bairro = bairro;

        context.Clientes.Add(cliente);
        context.SaveChanges();

        var response = new ClienteResponse(
            cliente.Id, 
            cliente.Nome,
            cliente.Apelido,
            cliente.Telefone,
            cliente.Cep,
            cliente.Endereco,
            cliente.Numero,
            cliente.BairroId,
            cliente.Bairro.Nome,
            cliente.Ativo);

        return Results.Created($"/cliente/{cliente.Id}", response);
    }
}
