﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Carritos
{
    public class CarritoDto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int  IdProducto { get; set; }
        public DateTime FechaRegistro { get; set;}
        public int Estado { get; set; }
    }
}
