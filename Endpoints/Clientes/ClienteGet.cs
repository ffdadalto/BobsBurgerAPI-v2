using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Clientes;

public class ClienteGet
{
    public static string Template => "/cliente/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, AppDbContext context)
    {
        var cliente = context.Clientes.Include(c => c.Bairro)
            .Where(s => s.Id == id).FirstOrDefault();

        if (cliente == null)
            return Results.NotFound();

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