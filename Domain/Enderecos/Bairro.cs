using BobsBurgerAPI_v2.Domain.Clientes;
using System.Text.Json.Serialization;

namespace BobsBurgerAPI_v2.Domain.Enderecos;

public class Bairro : Entity
{
    public int CidadeId { get; set; }    

    public Bairro(string nome, int cidadeId, bool ativo)
    {
        Nome = nome;  
        CidadeId = cidadeId;        
        Ativo = ativo;
        CriadoPor = "Dev";
        CriadodEm = DateTime.Now;
    }

    public void EditInfo(string nome, int cidadeId, bool ativo)
    {
        Nome = nome;        
        Ativo = ativo;
        CidadeId = cidadeId;
        EditadoPor = "Dev";
        EditadoEm = DateTime.Now;
    }
}
