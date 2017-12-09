using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebDSM.Models
{
    public class Pedido
    {

        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public string descripcion { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? fecha { get; set; }

        /* ILIST
        [ScaffoldColumn(false)]
        public LineaPedido lineaPedido { get; set; }
        */

        [ScaffoldColumn(false)]
        public Registrado registrado { get; set; }

        /*
        [ScaffoldColumn(false)]
        public Carrito carrito { get; set; }
        */

    }
}