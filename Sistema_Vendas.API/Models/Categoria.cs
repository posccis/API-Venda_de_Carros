using System.Collections.Generic;

namespace Sistema_Vendas.API.Models
{
    public class Categoria
    {
        public Categoria(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
           
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<SubCategoria> SubCategorias { get; set; }
    }
}