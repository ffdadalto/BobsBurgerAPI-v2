namespace BobsBurgerAPI_v2.Domain.Enderecos;

public class Bairro : Entity
{
    public int CidadeId { get; set; }
    public Cidade? Cidade { get; set; }

    public Bairro(string nome, bool ativo)
    {
        Nome = nome;        
        Ativo = ativo;
        CriadoPor = "Dev";
        CriadodEm = DateTime.Now;
    }

    public void EditInfo(string nome, bool ativo)
    {
        Nome = nome;        
        Ativo = ativo;
    }
}
