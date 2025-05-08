using Vendas.Api.Models.Enums;

namespace Vendas.Api.Models
{
    public class Sabor
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = default!; // Ex: "3 Queijos"
        public string Descricao { get; set; } = default!;
        public string Tag { get; set; } = default!; // Ex: "frango", "especial"
        public decimal ValorAdicional { get; set; }

        public int Tipo { get; set; } 
    }
}
