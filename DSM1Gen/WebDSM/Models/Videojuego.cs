using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CEN.DSM1;

namespace WebDSM.Models
{
    public class Videojuego
    {

        public List<SelectListItem> GetAllVideojuegos()
        {
            VideojuegoCEN cen = new VideojuegoCEN();

            //CONSIGO TODOS LOS VIDEOJUEGOS
            IEnumerable<VideojuegoEN> enumEN = cen.ReadAll(0, -1);

            List<SelectListItem> list = new List<SelectListItem>();

            foreach (VideojuegoEN vid in enumEN)
            {
                SelectListItem item = new SelectListItem { Value = vid.Id.ToString(), Text = vid.Nombre };

                list.Add(item);
            }

            return list;


        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre del videojuego", Description = "Nombre del videojuego", Name = "Nombre")]
        [Required(ErrorMessage = "Debe de indicar un nombre para el videojuego")]
        [StringLength(maximumLength: 50, MinimumLength = 0, ErrorMessage = "El nombre tiene que tener entre 0 y 50 caracteres")]
        public string Nombre { get; set; }

    }
}