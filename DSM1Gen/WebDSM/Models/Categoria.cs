using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DSM1GenNHibernate.CEN.DSM1;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class Categoria
    {
        
        public List<SelectListItem> getAllNombres()
        {

            CategoriaCEN cen = new CategoriaCEN();
            CategoriaEN en = new CategoriaEN();

            IEnumerable<CategoriaEN> listaEN = cen.get_ICategoriaCAD().ReadAll(0, -1);

            List<SelectListItem> miLista = new List<SelectListItem>();

            miLista.Add(new SelectListItem { Value = "0", Text = "Sin supercategoría" });

            foreach (CategoriaEN cat in listaEN)
            {
                SelectListItem item = new SelectListItem { Value = cat.Id.ToString(), Text = cat.Nombre };

                miLista.Add(item);
            }

            return miLista;
        }
        

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre de la categoría", Description = "Nombre de la categoría", Name = "Nombre")]
        [Required(ErrorMessage = "Debe de indicar un nombre para la categoría")]
        [StringLength(maximumLength: 50, MinimumLength = 0, ErrorMessage = "El nombre tiene que tener entre 0 y 50 caracteres")]
        public string Nombre { get; set; }
        
        /*
        [Display(Prompt = "Supercategoría de la categoría", Description = "Supercategoría de la categoría", Name = "Supercategoría")]
        [Required(ErrorMessage = "Debe de indicar una supercategoría para la categoría")]
        */

        [ScaffoldColumn(false)]
        public String NomSuper { get; set; }

        [ScaffoldColumn(false)]
        public int SuperId { get; set; }

        [ScaffoldColumn(false)]
        public List<Categoria> Subs { get; set; }

        [ScaffoldColumn(false)]
        public int Arts { get; set; }

    }
}