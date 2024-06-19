namespace ApiRestful.Models
{
    public interface IProdutoRepository
    {
        List<Produto> GetByID(string Id);
        List<Produto> GetByList();
        List<Produto> GetAll();
        void Insert(Produto produto);
        void Update(Produto produto);
        void Delete(string id);
    }
}
