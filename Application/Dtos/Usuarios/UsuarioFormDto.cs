namespace Application.Dtos.Usuarios
{
    public class UsuarioFormDto
    {
        public int IdRoles { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasenia { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
