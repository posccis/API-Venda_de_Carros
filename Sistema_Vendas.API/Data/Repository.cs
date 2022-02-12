using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sistema_Vendas.API.Models;

namespace Sistema_Vendas.API.Data
{
    public class Repository : IRepository
    {
        private readonly VendasContext _context;

        public Repository(VendasContext context)
        {
            _context = context;
        }
        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }

        public void Delete<T>(T Entity) where T : class
        {
            _context.Remove(Entity);
        }

        public Carro[] GetCarroByCateg(string Categ)
        {
            throw new System.NotImplementedException();
        }

        public Carro GetCarroById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Carro[] GetCarroByMarca(string Marca)
        {
            throw new System.NotImplementedException();
        }

        public Carro[] GetCarros()
        {
            throw new System.NotImplementedException();
        }

        public Motocicleta[] GetMoto()
        {
            throw new System.NotImplementedException();
        }

        public Motocicleta[] GetMotoByCateg(string Categ)
        {
            throw new System.NotImplementedException();
        }

        public Motocicleta GetMotoById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Motocicleta[] GetMotoByMarca(string Marca)
        {
            throw new System.NotImplementedException();
        }

        public Usuario GetUsuarioById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Usuario GetUsuarioEnder(int Id)
        {
            IQueryable<Usuario> query = _context.Usuarios;
            query = query.AsNoTracking().Where(user => user.Id == Id);
            query = query.AsNoTracking().Include(user => user.Endereco);

            return query.FirstOrDefault();

        }

        public Usuario[] GetUsuarios()
        {
            IQueryable<Usuario> query = _context.Usuarios;
            query = query.Include(a=> a.Endereco);
            query = query.Include(a=> a.Carros);
            query = query.Include(a=> a.Motocicletas);
            query = query.AsNoTracking().OrderBy(user => user.Id);
            return query.ToArray();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update<T>(T Entity) where T : class
        {
            _context.Update(Entity);
        }
    }
}