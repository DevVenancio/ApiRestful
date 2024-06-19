using ApiRestful.Models;
using ApiRestful.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestful.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException();
        }

        [HttpGet]
        [Route("api/produto/ConsultarProdutoPeloId")]
        public IActionResult GetProdutosById(ProdutoViewModel produto)
        {
            var prod = _produtoRepository.GetByID(produto.Id);

            return Ok(prod);
        }

        [HttpGet]
        [Route("api/produto/ConsultarProdutos")]
        public IActionResult GetProdutos()
        {
            var prod = _produtoRepository.GetAll();

            return Ok(prod);
        }

        [HttpPost]
        [Route("api/produto/InserirProduto")]
        public IActionResult InsertProdutos(ProdutoViewModel produto)
        {
            var prod = new Produto(produto.Id, produto.Nome, produto.Preco_unit, produto.Tipo);

            _produtoRepository.Insert(prod);

            return Ok();
        }

        [HttpPut]
        [Route("api/produto/AtualizarProduto")]
        public IActionResult UpdateProduto(ProdutoViewModel produto) 
        {
            var prod = new Produto(produto.Id, produto.Nome, produto.Preco_unit, produto.Tipo);

            _produtoRepository.Update(prod);

            return Ok();
        }

        [HttpDelete]
        [Route("api/produto/DeletarProdutor")]
        public IActionResult DeleteProduto(string id)
        {
            _produtoRepository.Delete(id);

            return Ok();
        }

    }
}
