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
    public class CategoriaController : BasicController
    {
        // GET: Categoria
        public ActionResult Index()
        {

            SessionInitialize();

            CategoriaCAD cad = new CategoriaCAD(session);
            CategoriaCEN cen = new CategoriaCEN(cad);

            IList<CategoriaEN> listEn = cen.ReadAll(0, -1);
            IEnumerable<Categoria> listModel = new AssemblerCategoria().ConvertListENToModel(listEn).ToList();

            SessionClose();


            return View(listModel);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();

            CategoriaCAD cad = new CategoriaCAD(session);
            CategoriaCEN cen = new CategoriaCEN(cad);

            CategoriaEN en = cad.ReadOIDDefault(id);
            Categoria model = new AssemblerCategoria().ConvertENToModelUI(en);


            SessionClose();


            return View(model);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {





            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(Models.Admin cat)
        {
            try
            {
                // TODO: Add insert logic here
                CategoriaCEN cen = new CategoriaCEN();

                int catId = cen.New_(cat.Categoria.Nombre, 0); //SE LE PASA 0, POR LOS LOLES

                if(cat.Categoria.SuperId != 0)
                    cen.Anyadir_supercat(catId,cat.Categoria.SuperId);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Admin cat)
        {
            try
            {
                CategoriaCEN cen = new CategoriaCEN();
                int n = cen.get_ICategoriaCAD().ReadOIDDefault(cat.Categoria.Id).Articulo;

                cen.Modify(cat.Categoria.Id, cat.Categoria.Nombre, n);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Web.HttpContext.Current.Session["PujaError"] = e.Message;
                return RedirectToAction("../Registrado/Admin");
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete(Models.Admin cat)
        {
            try
            {
                // TODO: Add insert logic here
                CategoriaCEN cen = new CategoriaCEN();

                cen.Destroy(cat.Categoria.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
