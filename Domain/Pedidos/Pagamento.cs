namespace BobsBurgerAPI_v2.Domain.Pedidos;

public class Pagamento : Entity
{
    public decimal Taxa { get; set; }
    public Pagamento(string nome, decimal taxa, bool ativo)
    {
        Nome = nome;        
        Ativo = ativo;
        Taxa = taxa;
        CriadoPor = "Dev";
        CriadodEm = DateTime.Now;
    }

    public void EditInfo(string nome, decimal taxa, bool ativo)
    {
        Nome = nome;   
        Taxa = taxa;
        Ativo = ativo;
        EditadoPor = "Dev";
        EditadoEm = DateTime.Now;
    }
}
