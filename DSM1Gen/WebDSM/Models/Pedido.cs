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
        public String Registrado { get; set; }

        //[ScaffoldColumn(false)]
        //public Carrito carrito { get; set; }

        [ScaffoldColumn(false)]
        public int Articulos { get; set; }

        [ScaffoldColumn(false)]
        public double Total { get; set; }
    }
}