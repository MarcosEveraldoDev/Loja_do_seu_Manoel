
using System.Text.Json.Serialization;

namespace Loja_do_Manuel.Inputs
{
    public class PedidoInput
    {
        [JsonPropertyName("pedido_id")]
        public int PedidoId { get; set; }

        [JsonPropertyName("produtos")]
        public List<ProdutoInput> Produtos { get; set; }
    }
}
