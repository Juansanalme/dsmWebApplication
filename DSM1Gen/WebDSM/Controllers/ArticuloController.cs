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
    public class ArticuloController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            SessionInitialize();
            ArticuloCAD articuloCAD = new ArticuloCAD(session);
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloCAD);
            IList<ArticuloEN> articulos = articuloCEN.ReadAll(0, 1);
            IEnumerable<Articulo> art = new AssemblerArticulo().ConvertListENToModel(articulos).ToList();
            SessionClose();
            return View();
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(Articulo art)
        {
            try
            {
                // TODO: Add insert logic here
                ArticuloCEN artCen = new ArticuloCEN();
                CategoriaCEN catCEN = new CategoriaCEN();
                
                /*
                int idCat =

                artCen.New_(art.nombre, art.precio, art.nomCategoria, art.descripcion, art.stock);
                */


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Articulo/Edit/5
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

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Articulo/Delete/5
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
