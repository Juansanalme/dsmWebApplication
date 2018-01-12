using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CEN.DSM1;
using WebDSM.Models;

namespace WebDSM.Controllers
{
    public class HomeController : BasicController
    {
        public ActionResult Index()
        {

            ArticuloCEN articuloCEN = new ArticuloCEN();
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN();

            IList<ArticuloEN> arts = articuloCEN.get_IArticuloCAD().ReadAll(0, -1);
            IList<VideojuegoEN> vids = videojuegoCEN.get_IVideojuegoCAD().ReadAll(0, -1);

            Index index = new AssemblerArticulo().Convert(arts, vids);

            return View(index);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}