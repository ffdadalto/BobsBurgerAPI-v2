using System.Text.Json.Serialization;

namespace BobsBurgerAPI_v2.Domain;

public abstract class Entity
{
    public int Id { get; set; }
    public string? Nome { get; set; }

    [JsonIgnore]
    public string? CriadoPor { get; set; }

    [JsonIgnore]
    public DateTime? CriadodEm { get; set; }

    [JsonIgnore]
    public string? EditadoPor { get; set; }

    [JsonIgnore]
    public DateTime? EditadoEm { get; set; }

    public bool Ativo { get; set; }
}

