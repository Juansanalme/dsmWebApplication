using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CEN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CP.DSM1;
using WebDSM.Models;
using WebMatrix.WebData;

namespace WebDSM.Controllers
{
    public class VideojuegoController : BasicController
    {

        // GET: Videojuego
        public ActionResult Index()
        {

            SessionInitialize();

            VideojuegoCAD cad = new VideojuegoCAD(session);
            VideojuegoCEN cen = new VideojuegoCEN(cad);

            IList<VideojuegoEN> listEn = cen.ReadAll(0, -1);
            IEnumerable<Videojuego> listModel = new AssemblerVideojuego().ConvertListENToModel(listEn).ToList();

            SessionClose();

            return View(listModel);
        }

        // GET: Videojuego/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Videojuego/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Videojuego/Create
        [HttpPost]
        public ActionResult Create(Models.Admin vid)
        {
            try
            {
                // TODO: Add insert logic here
                VideojuegoCEN cen = new VideojuegoCEN();

                int vidId = cen.New_(vid.Videojuego.Nombre, "");

                return RedirectToAction("../Registrado/Admin");
            }
            catch
            {
                return View();
            }
        }

        // GET: Videojuego/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Videojuego/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Admin vid)
        {
            try
            {
                VideojuegoCEN cen = new VideojuegoCEN();

                cen.Modify(vid.Videojuego.Id, vid.Videojuego.Nombre, "");
                return RedirectToAction("../Registrado/Admin");
            }
            catch (Exception e)
            {
                System.Web.HttpContext.Current.Session["PujaError"] = e.Message;
                return RedirectToAction("../Registrado/Admin");
            }
        }

        // GET: Videojuego/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Videojuego/Delete/5
        [HttpPost]
        public ActionResult Delete(Models.Admin vid)
        {
            try
            {
                // TODO: Add insert logic here
                VideojuegoCEN cen = new VideojuegoCEN();

                cen.Destroy(vid.Videojuego.Id);

                return RedirectToAction("../Registrado/Admin");
            }
            catch
            {
                return View();
            }
        }
    }
}
