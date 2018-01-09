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
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Fecha { get; set; }
        
        //[ScaffoldColumn(false)]
        //public DateTime? Tiempo { get; set; }  

        [ScaffoldColumn(false)]
        public String Registrado { get; set; }
        
        [ScaffoldColumn(false)]
        public int Puja { get; set; }

        [Display(Prompt = "Cantidad a pujar", Description = "En cantidades de dinero", Name = "Cantidad")]
        [Required(ErrorMessage = "Debes introducir una cifra")]
        [StringLength(maximumLength: 999999, MinimumLength = 0, ErrorMessage = "Tu puja debe superar a la puja minima")]
        public float Cantidad_puja { get; set; }

    }
}