using System.Text.Json.Serialization;

namespace Loja_do_Manuel.Outputs
{
    public class PedidoOutput
    {
        [JsonPropertyName("pedido_id")]
        public int PedidoId { get; set; }

        [JsonPropertyName("caixas")]
        public List<CaixaOutput> Caixas { get; set; } = new();
    }
}
