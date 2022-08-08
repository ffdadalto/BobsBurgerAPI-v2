namespace BobsBurgerAPI_v2.Domain.Pedidos;

public class Situacao : Entity
{
    public string? Cor { get; set; }
    public Situacao(string nome, string cor, bool ativo)
    {
        Nome = nome;
        Cor = cor;
        Ativo = ativo;
        CriadoPor = "Dev";
        CriadodEm = DateTime.Now;        
    }

    public void EditInfo(string nome, string cor, bool ativo)
    {
        Nome = nome;
        Cor= cor;
        Ativo = ativo;
        EditadoPor = "Dev";
        EditadoEm = DateTime.Now;
    }
}
