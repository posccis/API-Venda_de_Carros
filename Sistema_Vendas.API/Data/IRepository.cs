using System.Threading.Tasks;
using Sistema_Vendas.API.Models;

namespace Sistema_Vendas.API.Data
{
    public interface IRepository
    {
        void Add<T>(T Entity) where T : class;
        void Update<T>(T Entity) where T : class;
        void Delete<T>(T Entity) where T : class;
        bool SaveChanges();  

        //<--- Usuarios
        public Task<Usuario[]> GetUsuarios();
        public Task<Usuario> GetUsuarioById(int id);
        //public Task<Endereco> GetUsuarioEnder(int id);
        //--->Usuarios

        //<---Carros
        public Task<Carro[]> GetCarros();
        public Task<Carro[]> GetCarroById(int Id);           
        //public Task<Carro[]> GetCarroByMarca(string marca);
        //public Task<Carro[]> GetCarroByCateg(string categ);
        //--->Carros

        //<--- Motocicletas
        public Task<Motocicleta[]> GetMoto();
        public Task<Motocicleta[]> GetMotoById(int id);
       // public Task<Motocicleta[]> GetMotoByMarca(string marca);
       // public Task<Motocicleta[]> GetMotoByCateg(string categ);
        //--->Motocicletas
    }
}