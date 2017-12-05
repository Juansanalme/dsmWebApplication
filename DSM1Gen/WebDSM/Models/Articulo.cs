﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDSM.Models
{
    public class Articulo
    {
        //[ScaffoldColumn(false)] para aquellos atributos "invisibles", CREO
        //preguntar por EN

        [ScaffoldColumn(false)]
        public int id { get; set; }
        
        /*
        [ScaffoldColumn(false)]
        public LineaPedidoEN linped { get; set; }
        */

        /*
        [ScaffoldColumn(false)]
        public PujaEN puja { get; set; }
        */

        /*
        [ScaffoldColumn(false)]
        public RegistradoEN registrado { get; set; }
        */

        /*
        [ScaffoldColumn(false)]
        public Valoracion valoracion { get; set; }
        */

        [Display(Prompt = "Nombre del artículo", Description = "Nombre del artículo", Name = "Nombre" )]
        [Required(ErrorMessage = "Debe de indicar un nombre para el artículo")]
        [StringLength(maximumLength: 50, MinimumLength = 0, ErrorMessage = "El nombre tiene que tener entre 0 y 50 caracteres")]
        public string nombre { get; set; }

        [Display(Prompt = "Precio del artículo", Description = "Precio del artículo", Name = "Precio")]
        [Required(ErrorMessage = "Debe de indicar un precio para el artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe de ser un valor numérico")]
        [Range(minimum: 0, maximum: 9999999, ErrorMessage = "El precio debe de ser mayor que 0 y menor que 9999999")]
        public double precio { get; set; }

        [Display(Prompt = "Descripción del artículo", Description = "Descripción del artículo", Name = "Descripción")]
        [Required(ErrorMessage = "Debe de indicar una descripción para el artículo")]
        [StringLength(maximumLength: 200, MinimumLength = 0, ErrorMessage = "La descripción tiene que tener entre 0 y 200 caracteres")]
        public string descripcion { get; set; }

        [Display(Prompt = "Stock del artículo", Description = "Stock del artículo", Name = "Stock")]
        [Required(ErrorMessage = "Debe de indicar el stock inicial del artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El stock debe de ser un valor numérico")]
        [Range(minimum: 0, maximum: 9999999, ErrorMessage = "El stock inicial debe de ser mayor que 0 y menor que 9999999")]
        public int stock { get; set; }

        //Display
        //Required
        //DataType
        public Categoria categoria { get; set; } //PREGUNTAR









    }
}