namespace Sistema_Vendas.API.Models
{
    public class SubCategoria
    {
        public SubCategoria(int id, string subNome, int categoriaId)
        {
            this.Id = id;
            this.SubNome = subNome;
            this.CategoriaId = categoriaId;
        }
        public int Id { get; set; }
        public string SubNome { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }
}