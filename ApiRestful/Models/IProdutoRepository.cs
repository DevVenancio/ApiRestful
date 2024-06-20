using ApiRestful.DTOs;

namespace ApiRestful.Models
{
    public interface IProdutoRepository
    {
        List<ProdutoDTO> GetByID(string Id);
        List<ProdutoDTO> GetAll();
        List<DashboardDTO> GetDashboard();
        void Insert(Produto produto);
        void Update(Produto produto);
        void Delete(string id);

        bool IsExisting(string id);
    }
}
