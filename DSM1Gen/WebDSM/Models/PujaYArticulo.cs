using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDSM.Models
{
    public class PujaYArticulo
    {
        public PujaYArticulo()
        {
            Articulo = new Articulo();
            Puja = new Puja();
        }
        public Articulo Articulo { get; set; }
        public Puja Puja { get; set; }
    }
}