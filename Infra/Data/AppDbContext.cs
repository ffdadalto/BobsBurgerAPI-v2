using BobsBurgerAPI_v2.Domain.Enderecos;
using BobsBurgerAPI_v2.Domain.Pedidos;
using Microsoft.EntityFrameworkCore;

namespace BobsBurgerAPI_v2.Infra.Data;

public class AppDbContext : DbContext
{
    public DbSet<Situacao> Situacoes { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Bairro> Bairros { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(255);
    }

   // protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
   //{
   //    modelBuilder.Entity<Class>().Property(object => object.property).HasPrecision(12, 10);

   //    base.OnModelCreating(modelBuilder);
   //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pagamento>().Property(obj => obj.Taxa).HasPrecision(12, 2);
        base.OnModelCreating(modelBuilder);
    }

}
