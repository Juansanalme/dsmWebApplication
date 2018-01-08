using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CEN.DSM1;
using NHibernate;
using DSM1GenNHibernate.CAD.DSM1;

namespace WebDSM.Models
{
    public class Puja
    {

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Fecha { get; set; }

        [Display(Prompt = "Cantidad incial de la puja", Description = "En cantidades de dinero", Name = "Puja inicial")]
        [Required(ErrorMessage = "Debes introducir una cifra")]
        [StringLength(maximumLength: 999999, MinimumLength = 0, ErrorMessage = "Demasiado cara no crees")]
        public float PujaInicial { get; set; }

        [ScaffoldColumn(false)]
        public String UsuarioGanador { get; set; }
        
        [ScaffoldColumn(false)]
        public String Articulo { get; set; }

        [ScaffoldColumn(false)]
        public String ArtDescripcion { get; set; }

        [ScaffoldColumn(false)]
        public String Videojuego { get; set; }

        [ScaffoldColumn(false)]
        public float PujaMaxima { get; set; }
        
        //[ScaffoldColumn(false)]
        //public Ilist<int> Pujas { get; set; }

        //[ScaffoldColumn(false)]
        //public int IdUsuario { get; set; }

        [ScaffoldColumn(false)]
        public bool Cerrada { get; set; }

        [ScaffoldColumn(false)]
        public bool Pagada { get; set; }

        public List<SelectListItem> getAllNombres()
        {
            ISession session;
            session = NHibernateHelper.OpenSession();

            PujaCAD pujaCAD = new PujaCAD(session);
            PujaCEN pujaCEN = new PujaCEN(pujaCAD);

            IEnumerable<PujaEN> listaEN = pujaCEN.get_IPujaCAD().ReadAll(0, -1);

            List<SelectListItem> miLista = new List<SelectListItem>();
            

            foreach (PujaEN cat in listaEN)
            {
                
                SelectListItem item = new SelectListItem { Value = cat.Id.ToString(), Text = cat.Articulo.Nombre };
                if(!cat.Cerrada)
                    miLista.Add(item);
            }

            session.Close();
            session.Dispose();
            session = null;

            return miLista;
        }
    }
}