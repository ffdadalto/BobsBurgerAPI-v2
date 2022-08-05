using BobsBurgerAPI_v2.Domain.Enderecos;

namespace BobsBurgerAPI_v2.Endpoints.Bairros;

public class BairroResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int CidadeId { get; set; }
    public string NomeCidade { get; set; }

    public bool Ativo { get; set; }

    public BairroResponse(int id, string nome, int cidadeId, string nomeCidade, bool ativo)
    {
        Id = id;
        Nome = nome;
        CidadeId = cidadeId;    
        NomeCidade = nomeCidade;    
        Ativo = ativo;
    }
}