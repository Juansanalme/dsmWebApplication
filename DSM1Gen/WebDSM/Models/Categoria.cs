using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebDSM.Models
{
    public class Categoria
    {

        [ScaffoldColumn(false)]
        public int id { get; set; }

        /*
        [ScaffoldColumn(false)]
        public IList<Articulo> articulos { get; set; }

        [ScaffoldColumn(false)]
        public Categoria subCategoria { get; set; }

        [ScaffoldColumn(false)]
        public int nArticulos { get; set; }
        */


        [Display(Prompt = "Nombre de la categoría", Description = "Nombre de la categoría", Name = "Nombre")]
        [Required(ErrorMessage = "Debe de indicar un nombre para la categoría")]
        [StringLength(maximumLength: 50, MinimumLength = 0, ErrorMessage = "El nombre tiene que tener entre 0 y 50 caracteres")]
        public string nombre { get; set; }



        //???????
        [Display(Prompt = "Supercategoría de la categoría", Description = "Supercategoría de la categoría", Name = "Supercategoría")]
        [Required(ErrorMessage = "Debe de indicar una supercategoría para la categoría")]
        //DataType 
        public int superCategoria { get; set; }



    }
}