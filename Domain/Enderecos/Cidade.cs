namespace BobsBurgerAPI_v2.Domain.Enderecos;

public class Cidade : Entity
{
    public IEnumerable<Bairro> Bairros { get; set; }

    public Cidade(string nome, bool ativo)
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
        EditadoPor = "Dev";
        EditadoEm = DateTime.Now;
    }
}
