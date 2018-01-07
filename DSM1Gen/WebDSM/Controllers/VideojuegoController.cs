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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
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
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Videojuego/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Videojuego/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
