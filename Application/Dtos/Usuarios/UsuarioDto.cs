using Application.Dtos.Productos;
using Application.Dtos.Roles;

namespace Application.Dtos.Usuarios
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public int IdRoles { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public string? Direccion { get; set; }
        public int Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public RolDto Rol { get; set; }
        public  IList<ProductoDto> Productos { get; set; }
    }
}
