using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDSM.Models
{
    public class CarritoYLineas
    {
        public CarritoYLineas()
        {
            Carrito = new Carrito();
            LineaPedido = new List<LineaPedido>();
        }
        public Carrito Carrito { get; set; }
        public IList<LineaPedido> LineaPedido { get; set; }
    }
}