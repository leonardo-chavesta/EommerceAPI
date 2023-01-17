using Application.Dtos.Usuarios;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IUsuarioService
    {
        Task<UsuarioDto?> Autentifica(UsuarioFormLoginDto admin);

    }
}
