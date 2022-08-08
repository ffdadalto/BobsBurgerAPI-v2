namespace BobsBurgerAPI_v2.Endpoints.Clientes;

public class ClienteRequest
{    
    public string Nome { get; set; }
    public string? Apelido { get; set; }
    public string Telefone { get; set; }
    public string? Cep { get; set; }
    public string Endereco { get; set; }
    public string Numero { get; set; }
    public int BairroId { get; set; }    
    public bool Ativo { get; set; }
}
