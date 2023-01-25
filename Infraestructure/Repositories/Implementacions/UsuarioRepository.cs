using Azure;
using Domain;
using Infraestructure.Context;
using Infraestructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories.Implementacions
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AcountCorreo(string correo)
        {
            var user = await _context.Usuarios.AsNoTracking().DefaultIfEmpty().FirstOrDefaultAsync(u => u.Correo.Equals(correo));
            return user!;
        }

        public async Task<Usuario?> BuscarUsuario(int id)
         => await _context.Usuarios.FindAsync(id);

        public async Task<IList<Usuario>> ListaUsuarios()
            => await _context.Usuarios.Include(x => x.Rol).Include(x => x.Productos).OrderByDescending(e => e.Id).ToListAsync();

        public async Task<bool> Register(Usuario admin)
        {
            await _context.AddAsync(admin);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<Usuario> UserByCorreo(string email)
        {
            var user = await _context.Usuarios
                .AsNoTracking()
                .DefaultIfEmpty()
                .FirstOrDefaultAsync(u => u.Correo.Equals(email));
            return user;
        }
    }
}
