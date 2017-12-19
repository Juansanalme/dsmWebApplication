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
    }
}