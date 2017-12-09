using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebDSM.Models
{
    public class OfertaPuja
    {

        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? fecha { get; set; }

        //TIEMPO DEL SISTEMA
        [ScaffoldColumn(false)]
        public DateTime? tiempo { get; set; }

        //Y ESTO SE VE CON LA SESION ?
        [ScaffoldColumn(false)]
        public Registrado registrado { get; set; }

        //CALCULAR ESTO DE ALGUNA MANERA?
        [ScaffoldColumn(false)]
        public Puja puja { get; set; }

        [Display(Prompt = "Cantidad a pujar", Description = "En cantidades de dinero", Name = "Cantidad")]
        [Required(ErrorMessage = "Debes introducir una cifra")]
        [StringLength(maximumLength: 999999, MinimumLength = 0, ErrorMessage = "Tu puja debe superar a la puja minima")]
        public float cantidad_puja { get; set; }

    }
}