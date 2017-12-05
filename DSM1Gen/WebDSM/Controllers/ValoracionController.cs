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
        public ActionResult Create(Valoracion val)
        {
            try
            {

                // TODO: Add insert logic here
                ValoracionCEN valoracionEN = new ValoracionCEN();
                RegistradoCEN registradoCEN = new RegistradoCEN();

                int idUsu = 0;
                IList<RegistradoEN> regs = registradoCEN.ReadAll(0, -1);
                foreach (RegistradoEN aux in regs)
                {
                    if (aux.N_usuario == User.Identity.Name)
                    {
                        idUsu = aux.Id;

                        break;
                    }
                }
                
                valoracionEN.New_(val.puntuacion, val.texto, idUsu, val.articulo);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
        public ActionResult Delete(int id)
        {
            return View();
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
