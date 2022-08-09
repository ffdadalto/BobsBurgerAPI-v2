using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Clientes;

public class ClientePut
{
    public static string Template => "/cliente/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, ClienteRequest clienteRequest, AppDbContext context)
    {
        var cliente = context.Clientes
            .Include(c => c.Bairro)
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

        var bairro = context.Bairros.Where(c => c.Id == clienteRequest.BairroId).FirstOrDefault();        

        if(bairro == null)
            return Results.NotFound();

        cliente.Bairro = bairro;

        //context.Situacoes.Add(situacao);        
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

        return Results.Ok(response);
    }
}