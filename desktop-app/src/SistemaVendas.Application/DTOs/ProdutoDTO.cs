using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public decimal Preco { get; set; }

        public int QtdEstoque { get; set; }
    }
}
