using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace ApiRestful.Models
{
    public class ProdutoRequest
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public double? Preco_unit { get; set; }
        public string Tipo { get; set; }

    }
}
