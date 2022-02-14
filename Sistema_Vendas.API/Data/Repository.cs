using System.Linq;
using System.Threading.Tasks;
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
/*
        public async Task<Carro[]> GetCarroByCateg(string categ)
        {
            var carros = await _context.Carros.Where(car => car.Categoria == categ).ToArrayAsync();

            return carros;
        }


        public async Task<Carro[]> GetCarroByMarca(string marca)
        {
            var carros = await _context.Carros.Where(car => car.Marca == marca).ToArrayAsync();

            return carros;
        }
*/
        public async Task<Carro[]> GetCarros()
        {
            var carros = await _context.Carros.ToArrayAsync();

            return carros;
        }

        public async Task<Carro[]> GetCarroById(int id)
        {
            var carros = await _context.Carros.Where( moto => moto.UsuarioId == id).ToArrayAsync();

            return carros;
        }
        

        public async Task<Motocicleta[]> GetMoto()
        {
            var motos = await _context.Motocicletas.ToArrayAsync();

            return motos;
        }
        public async Task<Motocicleta[]> GetMotoById(int id)
        {
            var motos = await _context.Motocicletas.Where( moto => moto.UsuarioId == id).ToArrayAsync();

            return motos;
        }
/*
        public async Task<Motocicleta[]> GetMotoByCateg(string categ)
        {
            var motos = await _context.Motocicletas.Where( moto => moto.Categoria == categ).ToArrayAsync();

            return motos;
        }



        public async Task<Motocicleta[]> GetMotoByMarca(string marca)
        {
            var motos = await _context.Motocicletas.Where(moto => moto.Marca == marca).ToArrayAsync();

            return motos;
        }
*/
        public async Task<Usuario> GetUsuarioById(int id)
        {
            var user = await _context.Usuarios.Where(u => u.Id == id).ToArrayAsync();

            return user.FirstOrDefault();
        }
/*
        public async Task<Endereco> GetUsuarioEnder(int id)
        {

            var query = await _context.Usuarios.Where(user => user.Id == id).ToListAsync();
            var Ender = query.Find(user => user.Id == id).Endereco;

            return Ender;

        }
*/
        public async Task<Usuario[]> GetUsuarios()
        {
            IQueryable<Usuario> query = _context.Usuarios;
            query = query.Include(a=> a.Endereco);
            query = query.Include(a=> a.Carros);
            query = query.Include(a=> a.Motocicletas);
            query = query.AsNoTracking().OrderBy(user => user.Id);

            return await query.ToArrayAsync();
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