using System.Text.Json.Serialization;

namespace Loja_do_Manuel.Inputs
{
    public class DimensoesInput
    {
        [JsonPropertyName("altura")]
        public int Altura { get; set; }

        [JsonPropertyName("largura")]
        public int Largura { get; set; }

        [JsonPropertyName("comprimento")]
        public int Comprimento { get; set; }
    }
}
