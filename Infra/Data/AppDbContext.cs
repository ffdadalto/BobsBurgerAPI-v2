using BobsBurgerAPI_v2.Domain.Enderecos;
using BobsBurgerAPI_v2.Domain.Pedidos;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Infra.Data;

public class AppDbContext : DbContext
{
    public DbSet<Situacao> Situacoes { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Bairro> Bairros { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(255);
    }
}
