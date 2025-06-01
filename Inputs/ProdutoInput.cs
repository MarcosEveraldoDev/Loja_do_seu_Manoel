using System.Text.Json.Serialization;

namespace Loja_do_Manuel.Inputs
{
    public class ProdutoInput
    {
        [JsonPropertyName("produto_id")]
        public string ProdutoId { get; set; }

        [JsonPropertyName("dimensoes")]
        public DimensoesInput Dimensoes { get; set; }
    }
}
