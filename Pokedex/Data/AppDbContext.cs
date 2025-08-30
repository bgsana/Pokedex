using System.Formats.Tar;
using Microsoft.EntityFrameworkCore;
using Pokedex.Models;

namespace Pokedex.Data;

//contexto contem os objetos que representam as tabelas
public class AppDbContext : DbContext
{
    //construtor
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    //Conjunto de dados - Pega do db e converte para a programação, manipulando dps
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<PokemonTipo> PokemonTipos { get; set; }
    public DbSet<Regiao> Regioes { get; set; }
    public DbSet<Tipo> Tipos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        #region Muitos para Muitos do Pokemon Tipo
        //Configuração da chave primária
        builder.Entity<PokemonTipo>().HasKey(
            pt => new { pt.PokemonNumero, pt.TipoId }
        );

        //configuração de chave estrangeira - PokemonTipo -> Pokemon
        builder.Entity<PokemonTipo>()
            .HasOne(pt => pt.Pokemon)
            .WithMany(p => p.Tipos)
            .HasForeignKey(pt => pt.PokemonNumero);

        //configuração de chave estrangeira - PokemonTipo -> Tipo
        builder.Entity<PokemonTipo>()
            .HasOne(pt => pt.Tipo)
            .WithMany(t => t.Pokemons)
            .HasForeignKey(pt => pt.TipoId);
        #endregion

        
    }

}
