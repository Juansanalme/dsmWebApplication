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
        public int Id { get; set; }

        [Display(Prompt = "Nombre de la categoría", Description = "Nombre de la categoría", Name = "Nombre")]
        [Required(ErrorMessage = "Debe de indicar un nombre para la categoría")]
        [StringLength(maximumLength: 50, MinimumLength = 0, ErrorMessage = "El nombre tiene que tener entre 0 y 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Supercategoría de la categoría", Description = "Supercategoría de la categoría", Name = "Supercategoría")]
        [Required(ErrorMessage = "Debe de indicar una supercategoría para la categoría")]
        [StringLength(maximumLength: 50, MinimumLength = 0, ErrorMessage = "El nombre de la supercategoría tiene que tener entre 0 y 50 caracteres")]
        public string NomSuper { get; set; }



    }
}