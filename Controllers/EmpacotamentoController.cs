using Loja_do_Manuel.Inputs;
using Loja_do_Manuel.Models;
using Loja_do_Manuel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Loja_do_Manuel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpacotamentoController : Controller
    {
        private readonly ServicoDeEmpacotamento _empacotamento;

        public EmpacotamentoController(ServicoDeEmpacotamento empacotamento)
        {
            _empacotamento = empacotamento;
        }
        [HttpPost("empacotar")]
        public IActionResult EmpacotarPedidos([FromBody] EmpacotamentoInput input)
        {

            var pedidos = input.Pedidos.Select(p => new Pedido
            {
                PedidoId = p.PedidoId,
                Produtos = p.Produtos.Select(prod => new Produto
                {
                    ProdutoId = prod.ProdutoId,
                    Dimensoes = new Dimensoes
                    {
                        Altura = prod.Dimensoes.Altura,
                        Largura = prod.Dimensoes.Largura,
                        Comprimento = prod.Dimensoes.Comprimento
                    }
                }).ToList()
            }).ToList();

            var resultado = _empacotamento.ProcessarPedidos(pedidos);
            return Ok(resultado);
        }

    }
}
