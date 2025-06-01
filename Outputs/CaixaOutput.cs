using System.Text.Json.Serialization;

namespace Loja_do_Manuel.Outputs
{
    public class CaixaOutput
    {
        [JsonPropertyName("caixa_id")]
        public string? CaixaId { get; set; }

        [JsonPropertyName("produtos")]
        public List<string> Produtos { get; set; } = new();

        [JsonPropertyName("observacao")]
        public string? Observacao { get; set; }
    }
}
