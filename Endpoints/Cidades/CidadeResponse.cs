namespace BobsBurgerAPI_v2.Endpoints.Cidades;

public class CidadeResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int QtdBairros { get; set; }
    public bool Ativo { get; set; }

    public CidadeResponse(int id, string nome, int qtdBairros, bool ativo)
    {
        Id = id;
        Nome = nome;  
        QtdBairros = qtdBairros;
        Ativo = ativo;
    }
}