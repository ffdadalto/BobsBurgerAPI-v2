namespace BobsBurgerAPI_v2.Domain.Pedidos;

public class Situacao : Entity
{
    public string? Cor { get; set; }
    public Situacao(string nome, string cor)
    {
        Nome = nome;
        Cor = cor;
        Ativo = true;        
        CriadoPor = "Dev";
        CriadodEm = DateTime.Now;        
    }
}
