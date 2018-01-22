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
    public class ValoracionController : BasicController
    {
        // GET: Valoracion
        public ActionResult Index()
        {
            return View();
        }

        // GET: Valoracion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Valoracion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Valoracion/Create
        [HttpPost]
        public ActionResult Create(int rating, ArticuloYOpinion op)
        {
            ValoracionCEN cen = new ValoracionCEN();

            int idUsuario = (int)Session["idUsuario"];

            cen.New_(rating, op.Texto, idUsuario, op.IdArt);

            return RedirectToAction("Details", "Articulo", new { id = op.IdArt });
        }

        // GET: Valoracion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Valoracion/Edit/5
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

        // GET: Valoracion/Delete/5
        public ActionResult Delete(int id, int id2)
        {

            ValoracionCEN cen = new ValoracionCEN();

            cen.Destroy(id);


            return RedirectToAction("../Articulo/Details/"+id2);
        }

        // POST: Valoracion/Delete/5
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
