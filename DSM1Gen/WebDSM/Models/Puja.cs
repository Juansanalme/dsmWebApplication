using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebDSM.Models
{
    public class Puja
    {

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Fecha { get; set; }

        [Display(Prompt = "Cantidad incial de la puja", Description = "En cantidades de dinero", Name = "Puja inicial")]
        [Required(ErrorMessage = "Debes introducir una cifra")]
        [StringLength(maximumLength: 999999, MinimumLength = 0, ErrorMessage = "Demasiado cara no crees")]
        public float PujaInicial { get; set; }

        [ScaffoldColumn(false)]
        public String UsuarioGanador { get; set; }
        
        [ScaffoldColumn(false)]
        public String Articulo { get; set; }

        [ScaffoldColumn(false)]
        public String ArtDescripcion { get; set; }

        [ScaffoldColumn(false)]
        public float PujaMaxima { get; set; }
        
        //[ScaffoldColumn(false)]
        //public Ilist<int> Pujas { get; set; }

        //[ScaffoldColumn(false)]
        //public int IdUsuario { get; set; }

        [ScaffoldColumn(false)]
        public bool Cerrada { get; set; }

    }
}