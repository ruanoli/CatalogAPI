using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models {
    public class Produto {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
        public int Estoque { get; set; }
        public DateTime DataDeCadastro { get; set; }

        public int CategoriaId { get; set; }

        [JsonIgnore] 
        public Categoria? Categoria { get; set; } 

    }
}
