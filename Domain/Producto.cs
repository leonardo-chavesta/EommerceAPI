namespace Domain
{
    public class Producto
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }
        public int Flag { get; set; }
        public DateTime FechaRegistro { get; set;} = DateTime.Now;

        public virtual Categoria? Categoria { get; set; }
        public virtual Usuario? Usuario { get; set; }

        public virtual IList<Carrito> Carritos { get; set; }


    }
}
