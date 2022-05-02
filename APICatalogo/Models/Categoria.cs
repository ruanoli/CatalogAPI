using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APICatalogo.Models; 
public class Categoria {
    public Categoria() {
        Produtos = new Collection<Produto>();
    }
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome obrigatório")]
    [StringLength(80, ErrorMessage = "Tamanho máximo de 80 caracteres.")]
    public string? Nome { get; set; }

    [Required]
    [StringLength(200)]
    public string? ImagemUrl { get; set; }
    public ICollection<Produto>? Produtos { get; set; }
}
