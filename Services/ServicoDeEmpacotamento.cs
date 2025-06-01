using Loja_do_Manuel.Inputs;
using Loja_do_Manuel.Models;
using Loja_do_Manuel.Outputs;
using System.Linq;

namespace Loja_do_Manuel.Services
{
    public class ServicoDeEmpacotamento
    {
        private readonly List<(string Id, Dimensoes Dimensoes)> caixasDisponiveis = new()
        {
            ("Caixa 1", new Dimensoes { Altura = 30, Largura = 40, Comprimento = 80 }),
            ("Caixa 2", new Dimensoes { Altura = 80, Largura = 50, Comprimento = 40 }),
            ("Caixa 3", new Dimensoes { Altura = 50, Largura = 80, Comprimento = 60 })
        };

        public EmpacotamentoOutput ProcessarPedidos(List<Pedido> pedidos)
        {
            var resultado = new EmpacotamentoOutput();

            foreach (var pedido in pedidos)
            {
                var pedidoOutput = new PedidoOutput { PedidoId = pedido.PedidoId };
                var caixasUsadas = new List<CaixaOutput>();

     
                var produtosOrdenados = pedido.Produtos.OrderByDescending(p => p.Volume).ToList();

                foreach (var produto in produtosOrdenados)
                {
                    bool encaixado = false;

                    foreach (var caixa in caixasUsadas)
                    {
                        var modeloCaixa = caixasDisponiveis.FirstOrDefault(c => c.Id == caixa.CaixaId);
                        if (modeloCaixa == default) continue;

                        if (produto.Dimensoes.Altura <= modeloCaixa.Dimensoes.Altura &&
                            produto.Dimensoes.Largura <= modeloCaixa.Dimensoes.Largura &&
                            produto.Dimensoes.Comprimento <= modeloCaixa.Dimensoes.Comprimento)
                        {
                            double volumeCaixa = modeloCaixa.Dimensoes.Altura * modeloCaixa.Dimensoes.Largura * modeloCaixa.Dimensoes.Comprimento;
                            double volumeOcupado = caixa.Produtos.Sum(prodId =>
                                pedido.Produtos.First(p => p.ProdutoId == prodId).Volume);

                            if (volumeOcupado + produto.Volume <= volumeCaixa)
                            {
                                caixa.Produtos.Add(produto.ProdutoId);
                                encaixado = true;
                                break;
                            }
                        }
                    }

         
                    if (!encaixado)
                    {
                        var caixaAdequada = caixasDisponiveis
                            .Where(c =>
                                produto.Dimensoes.Altura <= c.Dimensoes.Altura &&
                                produto.Dimensoes.Largura <= c.Dimensoes.Largura &&
                                produto.Dimensoes.Comprimento <= c.Dimensoes.Comprimento)
                            .OrderBy(c => c.Dimensoes.Altura * c.Dimensoes.Largura * c.Dimensoes.Comprimento)
                            .FirstOrDefault();

                        if (caixaAdequada.Id != null)
                        {
                            caixasUsadas.Add(new CaixaOutput
                            {
                                CaixaId = caixaAdequada.Id,
                                Produtos = new List<string> { produto.ProdutoId }
                            });
                        }
                        else
                        {
                          
                            caixasUsadas.Add(new CaixaOutput
                            {
                                CaixaId = null,
                                Produtos = new List<string> { produto.ProdutoId },
                                Observacao = "Produto não cabe em nenhuma caixa disponível."
                            });
                        }
                    }
                }

                pedidoOutput.Caixas = caixasUsadas;
                resultado.Pedidos.Add(pedidoOutput);
            }

            return resultado;
        }
    }
}
