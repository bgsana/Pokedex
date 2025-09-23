using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Models;

[Table("Pokemon")]
public class Pokemon
{
    [Key]
    [Display(Name="Número")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public uint Numero { get; set; }

    [Required(ErrorMessage = "Deu errado :( Por favor, informe a Região")]
    public uint RegiaoId { get; set; }
    [ForeignKey("RegiaoId")]
    [Display(Name="Região")]
    public Regiao Regiao { get; set; }

    [Required(ErrorMessage = "Deu errado :( Por favor, informe o gênero do Pokemon")]
    public uint GeneroId { get; set; }
    [ForeignKey("GeneroId")]
    [Display(Name="Gênero")]
    public Genero Genero { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage = "Deu errado :( Por favor, informe o nome)")]
    public string Nome { get; set; }

    [StringLength(1000)]
    [Display(Name="Descrição")]
    public string Descricao { get; set; }

    [Column(TypeName = "double(5,2)")]
    [Required(ErrorMessage = "Deu errado :( Por favor, informe a altura")]
    public double Altura { get; set; }

    [Column(TypeName = "double(7,3)")]
    [Required(ErrorMessage = "Deu errado :( Por favor, informe o peso")]
    public double Peso { get; set; }

    [StringLength(200)]
    public string Imagem { get; set; }

    [StringLength(400)]
    [Display(Name="Animação")]
    public string Animacao { get; set; }

    public ICollection<PokemonTipo> Tipos { get; set; }
}
