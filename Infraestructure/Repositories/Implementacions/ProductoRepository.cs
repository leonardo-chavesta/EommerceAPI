using Domain;
using Infraestructure.Context;
using Infraestructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories.Implementacions
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Producto?> BuscarProducto(int id)
            => await _context.Productos.FindAsync(id);

        public async Task<Producto?> EditProducto(int id, Producto entity)
        {
            var model = await _context.Productos.FindAsync(id);
            if(model != null)
            {
                model.Nombre= entity.Nombre;
                model.Descripcion= entity.Descripcion;
                model.Flag= entity.Flag;
                model.Precio= entity.Precio;
                model.IdCategoria = entity.IdCategoria;

                _context.Productos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Producto?> EliminarProducto(int id)
        {
            var model = await _context.Productos.FindAsync(id);
            if (model != null)
            {
                model.Estado = (model.Estado == 0) ? 1 : 0;
                _context.Productos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Producto> GenerarProducto(Producto entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IList<Producto>> ListaProductos()
            => await _context.Productos.Include(x => x.Categoria).Where(x => x.Estado == 1).OrderByDescending(e => e.Id).ToListAsync();

        public async Task<IList<Producto>> ListarProductoAsync(string nombre, string categoria)
        {
            var response = await _context.Productos
                .Include(e => e.Categoria)
                .Where(e => (e.Estado == 1) &&
                            (string.IsNullOrWhiteSpace(categoria) || e.Categoria.Descripcion.ToUpper().Contains(categoria.ToUpper())) &&
                            (string.IsNullOrWhiteSpace(nombre) || e.Nombre.ToUpper().Contains(nombre.ToUpper())) 
                    )
                    .ToListAsync();

            if (response == null)
            {
                return null;
            }

            return response;
        }
    }
}
