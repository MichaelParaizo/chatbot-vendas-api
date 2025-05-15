using System.ComponentModel.DataAnnotations.Schema;

namespace Vendas.Api.Models
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public string Endereco { get; set; } = default!;
        public string Telefone { get; set; } = default!;
        public DateTime DataCadastro { get; set; }

      
    }
}