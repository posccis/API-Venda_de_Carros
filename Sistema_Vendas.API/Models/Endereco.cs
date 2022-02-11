namespace Sistema_Vendas.API.Models
{
    public class Endereco
    {
        public Endereco(int usuarioId, string rua, int numero, string bairro, string cidade, string estado)
        {
            this.UsuarioId = usuarioId;
            this.Rua = rua;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;            
        }
        public int UsuarioId { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}