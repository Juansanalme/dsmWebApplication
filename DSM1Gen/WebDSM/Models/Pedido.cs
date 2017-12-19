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
        public int Id { get; set; }

        //[ScaffoldColumn(false)]
        //public string Descripcion { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Fecha { get; set; }

        //[ScaffoldColumn(false)]
        //public IList<int> Lineas { get; set; }

        [ScaffoldColumn(false)]
        public int Registrado { get; set; }

        //[ScaffoldColumn(false)]
        //public Carrito carrito { get; set; }

    }
}