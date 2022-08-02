namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairroResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int CidadeId { get; set; }
    public bool Ativo { get; set; }

    public BairroResponse(int id, string nome, int cidadeId, bool ativo)
    {
        Id = id;
        Nome = nome;        
        CidadeId = cidadeId;
        Ativo = ativo;
    }
}
