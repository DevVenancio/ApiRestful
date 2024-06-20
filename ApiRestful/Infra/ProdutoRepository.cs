using ApiRestful.DTOs;
using ApiRestful.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRestful.Infra
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

        public List<DashboardDTO> GetDashboard()
        {
            return _connectionContext.Produtos
                        .GroupBy(x => x.produto_tipo)
                        .Select(y => new DashboardDTO
                        {
                            Quantidade = y.Count(),
                            MediaPreco = y.Average(p => p.preco_unit),
                            Tipo = y.Key
                        })
                        .ToList();
        }

        public List<ProdutoDTO> GetAll()
        {
            try
            {
                return _connectionContext.Produtos
                    .Select(x => 
                    new ProdutoDTO
                    {
                        Id = x.produto_id,
                        Nome = x.produto_nome,
                        PrecoUnit = x.preco_unit,
                        Tipo = x.produto_tipo
                    })
                    .ToList();
            }
            catch (Exception ex)
            {

                throw new NotImplementedException();
            }
            
        }

        public List<ProdutoDTO> GetByID(string Id)
        {
            try
            { 
                return _connectionContext.Produtos
                    .Where(x => x.produto_id == Id)
                    .Select(x => new ProdutoDTO
                    {
                        Id = x.produto_id,
                        Nome = x.produto_nome,
                        PrecoUnit = x.preco_unit,
                        Tipo = x.produto_tipo
                    })
                    .ToList();

            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public void Insert(Produto produto)
        {
            try
            {
                _connectionContext.Produtos.Add(produto);
                _connectionContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public void Update(Produto produto)
        {
            try
            {
                _connectionContext.Produtos.Update(produto);
                _connectionContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
            
        }

        public void Delete(string id)
        {
            try
            {
                _connectionContext.Produtos.Where(x => x.produto_id == id).ExecuteDelete();
                _connectionContext.SaveChanges();
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }

        public bool IsExisting(string id)
        {
            var item = GetByID(id);

            if (item.Count == 0)
            {
                return false; 
            }
            else
            {
                return true;
            }
        }

    }
}
