namespace Loja_do_Manuel.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public List<Produto> Produtos { get; set; } = new();
    }
}
