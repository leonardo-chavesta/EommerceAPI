namespace Domain
{
    public class Rol
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public virtual IList<Usuario> Usuarios { get; set; }
    }
}
