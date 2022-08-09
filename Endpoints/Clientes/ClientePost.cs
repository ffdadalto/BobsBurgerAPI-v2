using BobsBurgerAPI_v2.Domain.Clientes;
using BobsBurgerAPI_v2.Infra.Data;

namespace BobsBurgerAPI_v2.Endpoints.Clientes;

public class ClientePost
{
    public static string Template => "/cliente";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public record ClienteRequest(
         string Nome,
         string Apelido,
         string Telefone,
         string? Cep,
         string Endereco,
         string Numero,
         bool Ativo,
         int BairroId);

    public record ClienteResponse(
        int Id,
        string Nome,
        string Apelido,
        string Telefone,
        string? Cep,
        string Endereco,
        string Numero,
        bool Ativo,
        int BairroId);

    public static IResult Action(ClienteRequest clienteRequest, AppDbContext context)
    {
        var cliente = new Cliente(
            clienteRequest.Nome,
            clienteRequest.Apelido,
            clienteRequest.Telefone,
            clienteRequest.Cep,
            clienteRequest.Endereco,
            clienteRequest.Numero,
            clienteRequest.Ativo,
            clienteRequest.BairroId);

        if (cliente == null)
            return Results.BadRequest();        

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
            cliente.Ativo,
            cliente.BairroId);

        return Results.Created($"/cliente/{cliente.Id}", response);
    }
}
