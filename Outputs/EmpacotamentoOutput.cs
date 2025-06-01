using System.Text.Json.Serialization;

namespace Loja_do_Manuel.Outputs
{
    public class EmpacotamentoOutput
    {
        [JsonPropertyName("pedidos")]
        public List<PedidoOutput> Pedidos { get; set; } = new();
    }
}
