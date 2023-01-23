namespace Domain
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }

        public virtual IList<Productos> Productos { get; set; }
    }
}
