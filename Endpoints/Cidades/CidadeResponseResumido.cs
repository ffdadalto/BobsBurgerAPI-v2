namespace BobsBurgerAPI_v2.Endpoints.Cidades;

public class CidadeResponseResumido
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public CidadeResponseResumido(int id, string nome)
    {
        Id = id;
        Nome = nome;        
    }
}