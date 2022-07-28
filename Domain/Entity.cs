namespace BobsBurgerAPI_v2.Domain;

public abstract class Entity
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? CriadoPor { get; set; }
    public DateTime? CriadodEm { get; set; }
    public string? EditadoPor { get; set; }
    public DateTime? EditadoEm { get; set; }
    public bool Ativo { get; set; }
}

