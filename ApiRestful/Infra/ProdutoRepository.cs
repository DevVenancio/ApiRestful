using ApiRestful.Models;
using ApiRestful.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace ApiRestful.Infra
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ConnectionContext _connectionContext = new ConnectionContext();

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

        public List<Produto> GetAll()
        {
            try
            {
                return _connectionContext.Produtos.ToList();
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
            
        }

        public List<Produto> GetByID(string Id)
        {
            try
            { 
                return _connectionContext.Produtos.Where(x => x.produto_id == Id).ToList();
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

        public List<Produto> GetByList()
        {
            throw new NotImplementedException();
        }

        public void Insert(Produto produto)
        {
            try
            {
                _connectionContext.Produtos.Add(produto);
                _connectionContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Produto produto)
        {
            try
            {
                _connectionContext.Produtos.Update(produto);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
            
        }

    }
}
