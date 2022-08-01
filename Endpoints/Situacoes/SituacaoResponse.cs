namespace BobsBurgerAPI_v2.Endpoints.Situacoes;

public class SituacaoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public bool Ativo { get; set; }

    public SituacaoResponse(int id, string nome, bool ativo)
    {
        Id = id;
        Nome = nome;
        Ativo = ativo;
    }
}
