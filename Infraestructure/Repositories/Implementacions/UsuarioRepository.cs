using Domain;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories.Implementacions
{
    public class UsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> Auten(Usuario admin)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(
                x => x.Nombre == admin.Nombre && 
                x.Correo == admin.Correo);
        }

    }
}
