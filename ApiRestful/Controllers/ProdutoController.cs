using ApiRestful.DTOs;
using ApiRestful.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        [Route("api/produto/ConsultarProdutoPeloId")]
        public IActionResult GetProdutosById(ProdutoRequest produto)
        {
            if (!_produtoRepository.IsExisting(produto.Id))
                return BadRequest();

            var prod = _produtoRepository.GetByID(produto.Id);

            return Ok(prod);
        }

        [Authorize]
        [HttpGet]
        [Route("api/produto/ConsultarProdutos")]
        public IActionResult GetProdutos()
        {
            var prod = _produtoRepository.GetAll();

            return Ok(prod);
        }

        [Authorize]
        [HttpGet]
        [Route("api/produto/Dashboard")]
        public IActionResult GetDashboard()
        {
            var prod = _produtoRepository.GetDashboard();

            return Ok(prod);
        }

        [Authorize]
        [HttpGet]
        [Route("api/produto/ConsultarProdutosLista")]
        public IActionResult GetProdutosByLista(List<string> id)
        {
            var prodResponse = new List<ProdutoDTO>();
            foreach (var i in id){

                if (!_produtoRepository.IsExisting(i))
                    return BadRequest();

                var prod = _produtoRepository.GetByID(i);
                prodResponse.Add(prod.First());
            }

            return Ok(prodResponse);
        }

        [Authorize]
        [HttpPost]
        [Route("api/produto/InserirProduto")]
        public IActionResult InsertProdutos(List<ProdutoRequest> produto)
        {
            foreach (var item in produto)
            {
                if (_produtoRepository.IsExisting(item.Id))
                    return BadRequest();

                var prod = new Produto(item.Id, item.Nome, item.Preco_unit, item.Tipo);

                _produtoRepository.Insert(prod);
            }

            return Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("api/produto/AtualizarProduto")]
        public IActionResult UpdateProduto(ProdutoRequest produto) 
        {
            if (!_produtoRepository.IsExisting(produto.Id))
                return BadRequest();

            var prod = new Produto(produto.Id, produto.Nome, produto.Preco_unit, produto.Tipo);

            _produtoRepository.Update(prod);

            return Ok();
        }

        [Authorize]
        [HttpDelete]
        [Route("api/produto/DeletarProdutor")]
        public IActionResult DeleteProduto(string id)
        {
            if (!_produtoRepository.IsExisting(id))
                return BadRequest();

            _produtoRepository.Delete(id);

            return Ok();
        }

    }
}
