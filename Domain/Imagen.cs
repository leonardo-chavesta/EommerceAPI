namespace Domain
{
    public class Imagen
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Url { get; set; }
        public int Estado { get; set; } = 1;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
