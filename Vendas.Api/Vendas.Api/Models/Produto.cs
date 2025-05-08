namespace Vendas.Api.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = default!;
        public string Descricao { get; set; } = default!;
    }
}
