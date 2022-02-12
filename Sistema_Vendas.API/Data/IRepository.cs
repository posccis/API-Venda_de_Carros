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
        public Usuario[] GetUsuarios();
        public Usuario GetUsuarioById(int Id);
        public Usuario GetUsuarioEnder(int Id);
        //--->Usuarios

        //<---Carros
        public Carro[] GetCarros();
        public Carro GetCarroById(int Id);           
        public Carro[] GetCarroByMarca(string Marca);
        public Carro[] GetCarroByCateg(string Categ);
        //--->Carros

        //<--- Motocicletas
        public Motocicleta[] GetMoto();
        public Motocicleta GetMotoById(int Id);
        public Motocicleta[] GetMotoByMarca(string Marca);
        public Motocicleta[] GetMotoByCateg(string Categ);
        //--->Motocicletas
    }
}