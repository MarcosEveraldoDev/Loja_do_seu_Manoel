using System.Text.Json.Serialization;

namespace Loja_do_Manuel.Inputs
{
    public class EmpacotamentoInput
    {
        [JsonPropertyName("pedidos")]
        public List<PedidoInput> Pedidos { get; set; }
    }
}
