namespace BobsBurgerAPI_v2.Endpoints.Situacoes;

public class SituacaoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public SituacaoResponse(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}
