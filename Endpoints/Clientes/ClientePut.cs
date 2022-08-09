using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Clientes;

public class ClientePut
{
    public static string Template => "/cliente/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

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

    public record ClienteRequest(        
        string Nome,
        string Apelido,
        string Telefone,
        string? Cep,
        string Endereco,
        string Numero,
        bool Ativo,
        int BairroId);

    public static IResult Action([FromRoute] int id, ClienteRequest clienteRequest, AppDbContext context)
    {
        var cliente = context.Clientes            
            .Where(s => s.Id == id).FirstOrDefault();

        if (cliente == null)
            return Results.NotFound();

        cliente.EditInfo(
            clienteRequest.Nome, 
            clienteRequest.Apelido,
            clienteRequest.Telefone,
            clienteRequest.Cep,
            clienteRequest.Endereco,
            clienteRequest.Numero,
            clienteRequest.BairroId,
            clienteRequest.Ativo);        
                
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

        return Results.Ok(response);
    }
}