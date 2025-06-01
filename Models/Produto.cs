namespace Loja_do_Manuel.Models
{
    public class Produto
    {
        public string ProdutoId { get; set; }
        public Dimensoes Dimensoes { get; set; }
        public int Volume => Dimensoes.Altura * Dimensoes.Largura * Dimensoes.Comprimento;
    }
}
