namespace BobsBurgerAPI_v2.Endpoints.Pagamentos;

public class PagamentoRequest
{
    public string Nome { get; set; }
    public decimal Taxa { get; set; }
    public bool Ativo { get; set; }
}