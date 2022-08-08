using BobsBurgerAPI_v2.Domain.Enderecos;

namespace BobsBurgerAPI_v2.Endpoints.Clientes;

public class ClienteResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? Apelido { get; set; }
    public string Telefone { get; set; }
    public string? Cep { get; set; }
    public string Endereco { get; set; }
    public string Numero { get; set; }
    public int BairroId { get; set; }
    public string NomeBairro { get; set; }
    public bool Ativo { get; set; }

    public ClienteResponse(int id, string nome, string apelido, string telefone, string cep, string endereco,
        string numero, int bairroId, string nomeBairro, bool ativo)
    {
        Id = id;
        Nome = nome;
        Apelido = apelido;
        Telefone = telefone;
        Cep = cep;
        Endereco = endereco;
        Numero = numero;
        BairroId = bairroId;
        NomeBairro = nomeBairro;
        Ativo = ativo;
    }
}