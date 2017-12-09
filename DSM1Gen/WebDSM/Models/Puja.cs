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
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? fecha { get; set; }

        [Display(Prompt = "Cantidad incial de la puja", Description = "En cantidades de dinero", Name = "Pueja inicial")]
        [Required(ErrorMessage = "Debes introducir una cifra")]
        [StringLength(maximumLength: 999999, MinimumLength = 0, ErrorMessage = "Demasiado cara no crees")]
        public float pujaInicial { get; set; }

        [ScaffoldColumn(false)]
        public Registrado usuarioGanador { get; set; }

        //NO SE COMO SACAR ESTO
        [ScaffoldColumn(false)]
        public Articulo articulo { get; set; }

        [ScaffoldColumn(false)]
        public float pujaMaxima { get; set; }
        
        //[ScaffoldColumn(false)]
        //public Ilist<OfertaPuja> pujas { get; set; }

        // QUE ES ESTO ?
        [ScaffoldColumn(false)]
        public int idUsuario { get; set; }

        [ScaffoldColumn(false)]
        public bool cerrada { get; set; }

    }
}