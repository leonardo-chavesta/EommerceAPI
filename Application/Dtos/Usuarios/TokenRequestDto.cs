using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Usuarios
{
    public class TokenRequestDto
    {
        public string? Correo { get; set; }
        public string? Contrasenia { get; set; }
    }
}
