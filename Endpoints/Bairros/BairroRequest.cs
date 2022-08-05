namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairroRequest
{
    public string? Nome { get; set; }
    public int CidadeId { get; set; }
    public bool Ativo { get; set; }
}
