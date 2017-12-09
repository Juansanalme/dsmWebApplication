using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebDSM.Models
{
    public class Carrito
    {
        //id, registrado, linped, precio, pedido

        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public Registrado usuario { get; set; }
        
        //AL CREARLO EL PRECIO SERA CERO
        [ScaffoldColumn(false)]
        public double precio { get; set; }

        /*
        [ScaffoldColumn(false)]
        public IList<LineaPedido> lineaPedido { get; set; }
        
        [ScaffoldColumn(false)]
        public Pedido pedido { get; set; }
        */




    }
}