using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CEN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CP.DSM1;
using WebDSM.Models;

namespace WebDSM.Controllers
{
    public class PujaController : BasicController
    {
        // GET: Puja
        public ActionResult Index()
        {
            SessionInitialize();

            PujaCAD pujaCAD = new PujaCAD(session);
            PujaCEN pujaCEN = new PujaCEN(pujaCAD);

            IList<PujaEN> pujas = pujaCEN.ReadAll(0, -1);
            IEnumerable<Puja> puj = new AssemblerPuja().ConvertListENToModel(pujas).ToList();

            SessionClose();

            return View(puj);
        }

        // GET: Puja/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();

            PujaCAD pujaCAD = new PujaCAD(session);
            PujaCEN pujaCEN = new PujaCEN(pujaCAD);

            PujaEN pujaEN = pujaCAD.ReadOIDDefault(id);
            Puja puj = new AssemblerPuja().ConvertENToModelUI(pujaEN);
            SessionClose();

            return View(puj);
        }

        // GET: Puja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puja/Create
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

        // GET: Puja/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Puja/Edit/5
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

        // GET: Puja/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Puja/Delete/5
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
