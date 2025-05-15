using System.ComponentModel.DataAnnotations.Schema;

namespace Vendas.Api.Models
{
    public class Adicional
    {

        public Adicional()
        {
            
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Titulo { get; set; } = default!;
        public string Tipo { get; set; }=default!; // Ex: "Borda", "Ingrediente extra"
        public decimal Valor { get; set; }
    }
}
