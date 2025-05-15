using System.ComponentModel.DataAnnotations.Schema;
using Vendas.Api.Models.Enums;

namespace Vendas.Api.Models
{
    public class Pagamento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public FormaPagamento Forma { get; set; } // Enum: Débito, Crédito, Dinheiro, Pix
        public DateTime DataPagamento { get; set; }
        public bool Pago { get; set; }

       
    }
}
