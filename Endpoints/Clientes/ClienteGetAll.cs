using BobsBurgerAPI_v2.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Endpoints.Clientes;


public class ClienteGetAll
{
    public static string Template => "/cliente";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
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

    public static IResult Action(AppDbContext context)
    {
        var clientes = context.Clientes;

        var response = clientes.OrderByDescending(s => s.Id)
            .Select(s => new ClienteResponse(
                s.Id,
                s.Nome,
                s.Apelido,
                s.Telefone,
                s.Cep,
                s.Endereco,
                s.Numero,
                s.Ativo,
                s.BairroId));

        return Results.Ok(response);
    }
}
