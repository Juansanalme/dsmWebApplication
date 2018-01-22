using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace WebDSM.Models
{
    public class Index
    {
        public Index()
        {
            Articulos = new List<Articulo>();
            Videojuegos = new List<Videojuego>();
        }
        public IList<Articulo> Articulos { get; set; }
        public IList<Videojuego> Videojuegos { get; set; }
    }
}