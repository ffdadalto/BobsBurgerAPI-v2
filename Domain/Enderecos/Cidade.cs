namespace BobsBurgerAPI_v2.Domain.Enderecos;

public class Cidade : Entity
{
    public virtual List<Bairro> Bairros { get; set; }
    public Cidade(string nome, bool ativo)
    {
        Nome = nome;
        Ativo = ativo;
        Bairros = new List<Bairro>();
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
