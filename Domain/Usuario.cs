namespace Domain
{
    public class Usuario 
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

        public virtual Rol Rol { get; set; }
        public virtual IList<Producto> Productos { get; set; }
    }
}
