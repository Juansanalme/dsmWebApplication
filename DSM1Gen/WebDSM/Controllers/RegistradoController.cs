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
using DSM1GenNHibernate.Utils;


namespace WebDSM.Controllers
{
    public class RegistradoController : BasicController
    {

        // GET: Registrado
        public ActionResult Index()
        {
            //ESTO ES MU IMPORTANTE
            SessionInitialize();

            RegistradoCAD cad = new RegistradoCAD(session);
            RegistradoCEN cen = new RegistradoCEN(cad);

            IList<RegistradoEN> listEN = cen.ReadAll(0, -1);

            IEnumerable<Registrado> enumR = new AssemblerRegistrado().ConvertListENToModel(listEN).ToList();

            SessionClose();

            //CREA UNA VISTA QUE REPRESENTA ESOS DATOS
            return View(enumR);
        }

        // GET: Registrado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registrado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registrado/Create
        [HttpPost]
        [AllowAnonymous]            
        [ValidateAntiForgeryToken]  //IMPIDE LA FALSIFICACION DE UNA SOLICITUD
        public ActionResult Create(Registrado reg)
        {
            try
            {
                // TODO: Add insert logic here
                RegistradoCP cp = new RegistradoCP();

                RegistradoEN usuSingUp = cp.Nuevo_usuarioYcarrito(reg.Nombre, reg.Apellidos, reg.Edad, reg.FNacimiento, reg.Dni, reg.Contrasenya, reg.NUsuario, false);

                //ENCRIPTACION DE LA CONTRASENYA
                string encContra = Util.GetEncondeMD5(reg.Contrasenya);

                //WebSecurity.CreateUserAndAccount(reg.NUsuario, encContra);    //REGISTRO EN LA BDD LITE DE SQL SERVER
                //WebSecurity.Login(reg.NUsuario, encContra);                   //LOGIN
                

                return RedirectToAction("Index");
            }
            catch
            {
                //NO SE SI HAY QUE PASAR reg A LA VISTA
                return View(reg); 
            }
        }

        // GET: Registrado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registrado/Edit/5
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

        // GET: Registrado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registrado/Delete/5
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
