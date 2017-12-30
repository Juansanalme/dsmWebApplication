using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace WebDSM.Models
{
    public class ArticuloYOpinion
    {
        public ArticuloYOpinion()
        {
            Articulo = new Articulo();
            Valoracion = new List<Valoracion>();
        }
        public Articulo Articulo {get; set;}
        public IList<Valoracion> Valoracion {get; set;}


        //ATRIBUTOS PARA QUE SE PUEDAN CREAR LAS VALORACIONES
        [Display(Prompt = "Texto de la valoración", Description = "Texto de la valoración", Name = "Texto")]
        [Required(ErrorMessage = "Debe de indicar un texto para la valoración")]
        [StringLength(maximumLength: 500, MinimumLength = 0, ErrorMessage = "El texto tiene que tener entre 0 y 500 caracteres")]
        public string Texto { get; set; }

        [Display(Prompt = "Puntuación de la valoración", Description = "Puntuación de la valoración", Name = "Puntuación")]
        [Required(ErrorMessage = "Debe de indicar una puntuación para la valoración del artículo")]
        [DataType(DataType.Currency, ErrorMessage = "La puntuación debe de ser un valor numérico")]
        [Range(minimum: 0, maximum: 10, ErrorMessage = "La puntuación debe ser un valor numérico entre 0 y 10")]
        public int Puntuacion { get; set; }

        [ScaffoldColumn(false)]
        public int IdArt { get; set; }
    }
}