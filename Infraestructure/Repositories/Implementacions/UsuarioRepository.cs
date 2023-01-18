﻿using Domain;
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

        public Task<Usuario?> Autentifica(Usuario admin)
        {
            throw new NotImplementedException();
        }
    }
}
