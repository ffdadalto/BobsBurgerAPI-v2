namespace BobsBurgerAPI_v2.Domain.Pedidos;

public class Situacao : Entity
{
    public Situacao(string nome)
    {
        Nome = nome;
        Ativo = true;
        CriadoPor = "Dev";
        CriadodEm = DateTime.Now;
    }

}
