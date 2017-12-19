using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDSM.Models
{
    public class ArticuloYOpinion
    {
        public ArticuloYOpinion()
        {
            articulo = new Articulo();
            valoracion = new Valoracion();
        }
        public Articulo articulo {get; set;}
        public Valoracion valoracion {get; set;}
    }
}