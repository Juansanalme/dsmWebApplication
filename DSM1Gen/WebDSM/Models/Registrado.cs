using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebDSM.Models
{
    public class Registrado
    {

        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public bool admin { get; set; }

        //[ScaffoldColumn(false)]
        //public Valoracion valoracion { get; set;} //LISTA DE VALORACIONES DEL USUARIO

        //[ScaffoldColumn(false)]
        //public Pedido pedido { get; set; } //LISTA DE PEDIDOS DEL USUARIO

        //NO SE SI ES ASI
        //[ScaffoldColumn(false)]
        //public Carrito carrito { get; set; }

        //[ScaffoldColumn(false)]
        //public Puja pujaGanadora { get; set; }

        //[ScaffoldColumn(false)]
        //public IList<Articulo> favoritos { get; set; }

        //[ScaffoldColumn(false)]
        //public OfertaPuja ofertaPuja { get; set; }




        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int edad { get; set; }
        public DateTime fNacimiento { get; set; }
        public string contrasenya { get; set; }
        public string nUsuario { get; set; }
        
        




    }
}