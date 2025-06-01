using System.Text.Json.Serialization;

namespace Loja_do_Manuel.Models
{
    public class ResultadoEmpacotamento
    {
        [JsonPropertyName("pedidos")]
        public List<ResultadoPedido> Pedidos { get; set; } = new();
    }

    public class ResultadoPedido
    {
        [JsonPropertyName("pedido_id")]
        public int PedidoId { get; set; }

        [JsonPropertyName("caixas")]
        public List<Caixa> Caixas { get; set; } = new();
    }
}
