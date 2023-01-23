using Domain;
using Infraestructure.Context;
using Infraestructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories.Implementacions
{
    public class CarritoRepository : ICarritoRepository
    {
        private readonly ApplicationDbContext _context;
        public CarritoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Carrito?> BucarProductosCarrito(int id)
        {
            var response = await _context.Carritos.FindAsync(id);
            
            return response;
        }

        public async Task<Carrito> CrearCarrito(Carrito entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Carrito?> EliminarProductoDelCarrito(int id)
        {
            var model = await _context.Carritos.FindAsync(id);
            if (model != null)
            {
                model.Estado = (model.Estado == 0) ? 1 : 0;
                _context.Carritos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
       

        public async Task<IList<Carrito>> ListarCarrito()
            => await _context.Carritos.Where(x => x.Estado == 1).OrderByDescending(e => e.Id).ToListAsync();

    }
}
