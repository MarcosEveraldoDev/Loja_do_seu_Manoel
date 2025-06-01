using System.Text.Json.Serialization;

namespace Loja_do_Manuel.Models
{
    public class Caixa
    {
        public string CaixaId { get; set; }
        public List<string> Produtos { get; set; } = new();
        public string? Observacao { get; set; } = null;
    }
}
