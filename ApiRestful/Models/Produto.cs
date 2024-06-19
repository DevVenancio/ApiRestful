using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRestful.Models
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        public string produto_id { get; set; }
        public string produto_nome { get; set; }
        public double? preco_unit { get; set; }
        public string produto_tipo { get; set; }

        public Produto(string produto_id, string produto_nome, double? preco_unit, string produto_tipo)
        {
            this.produto_nome = produto_nome;
            this.produto_id = produto_id;
            this.preco_unit = preco_unit;
            this.produto_tipo = produto_tipo;
        }
    }

}
