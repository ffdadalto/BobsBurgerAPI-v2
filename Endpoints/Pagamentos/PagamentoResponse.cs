namespace BobsBurgerAPI_v2.Endpoints.Pagamentos;

public class PagamentoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Taxa { get; set; }
    public bool Ativo { get; set; }

    public PagamentoResponse(int id, string nome, decimal taxa, bool ativo)
    {
        Id = id;
        Nome = nome;        
        Taxa = taxa;
        Ativo = ativo;
    }
}