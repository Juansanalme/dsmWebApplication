using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DSM1GenNHibernate.CEN.DSM1;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class Carrito
    {
        //id, registrado, linped, precio, pedido
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public String Usuario { get; set; }
        
        [ScaffoldColumn(false)]
        public double Precio { get; set; }

        //[ScaffoldColumn(false)]
        //public LineaPedido Linea { get; set; }

        //[ScaffoldColumn(false)]
        //public Pedido Pedido { get; set; }

    }
}