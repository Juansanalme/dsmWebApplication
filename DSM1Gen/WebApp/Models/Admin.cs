using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDSM.Models
{
    public class Admin
    {
        public Admin()
        {
            Articulo = new Articulo();
            Categoria = new Categoria();
            Puja = new Puja();
            Registrado = new List<Registrado>();
            Videojuego = new Videojuego();
        }
        public Articulo Articulo { get; set; }
        public Categoria Categoria { get; set; }
        public Puja Puja { get; set; }
        public IList<Registrado> Registrado { get; set; }
        public Videojuego Videojuego { get; set; }
    }
}