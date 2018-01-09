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
using System.IO;

namespace WebDSM.Controllers
{
    public class RegistradoController : BasicController
    {
        // GET: Registrado/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Registrado/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]  //IMPIDE LA FALSIFICACION DE UNA SOLICITUD
        public ActionResult Login(Registrado reg)
        {
            try
            {
                // TODO: Add insert logic here
                RegistradoCEN cen = new RegistradoCEN();

                int finalID = 0;
                bool admin = false;
                IList<RegistradoEN> listEN = cen.get_IRegistradoCAD().ReadAll(0, -1);
                foreach(RegistradoEN rEN in listEN)
                {
                    if(rEN.N_usuario == reg.NUsuario)
                    {
                        finalID = rEN.Id;
                        admin = rEN.Admin;
                        break;
                    }
                }
                
                //RegistradoEN en = cen.get_IRegistradoCAD().ReadOIDDefault(finalID);

                bool login = cen.Login(finalID, reg.Contrasenya, reg.NUsuario);

                if (login)
                {
                    System.Web.HttpContext.Current.Session["login"] = reg.NUsuario;
                    System.Web.HttpContext.Current.Session["idUsuario"] = finalID; //LO NECESITARE MÁS ADELANTE PARA OPERACIONES CON EL CARRITO
                    System.Web.HttpContext.Current.Session["admin"] = admin;

                    //Cojo el numero de articulos en el carrito
                    SessionInitialize();
                    CarritoCAD carritoCAD = new CarritoCAD(session);
                    CarritoCEN carritoCEN = new CarritoCEN(carritoCAD);
                    CarritoEN en = carritoCEN.get_ICarritoCAD().ReadOIDDefault(finalID);
                    CarritoYLineas model = new AssemblerCarrito().ConvertENToViewModelUI(en);
                    System.Web.HttpContext.Current.Session["nCarrito"] = model.LineaPedido.Count();
                    SessionClose();
                    //Cojo la foto de perfil
                    System.Web.HttpContext.Current.Session["foto"] = "../../Images/Shut-up-and-take-my-money!.png";
                    RegistradoCAD cad = new RegistradoCAD();
                    RegistradoEN registradoEN = cad.ReadOIDDefault(finalID);
                    Registrado img = new AssemblerRegistrado().ConvertENToModelUI(registradoEN);
                    string idUsu = img.Id.ToString();
                    string iconoUsu = Path.Combine(Server.MapPath("~/Content/Uploads/User_icons"), idUsu);
                    if ((System.IO.File.Exists(iconoUsu + ".jpg"))) Session["foto"] = img.Id + ".jpg";
                    else if ((System.IO.File.Exists(iconoUsu + ".jpeg"))) Session["foto"] = img.Id + ".jpeg";
                    else if ((System.IO.File.Exists(iconoUsu + ".png"))) Session["foto"] = img.Id + ".png";
                    else if ((System.IO.File.Exists(iconoUsu + ".gif"))) Session["foto"] = img.Id + ".gif";

                    return RedirectToAction("../Home");
                }
                else
                {
                    return View(reg);
                }

            }
            catch
            {
                return View(reg);
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("../Home");
        }

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

        // GET: Registrado/Perfil/5
        public ActionResult Perfil()
        {
            try
            {
                int id = (int)Session["idUsuario"];

                RegistradoCAD cad = new RegistradoCAD();
                RegistradoEN en = cad.ReadOIDDefault(id);

                Registrado model = new AssemblerRegistrado().ConvertENToModelUI(en);

                //SACO EL ICONO DEL USUARIO
                string idUsu = model.Id.ToString();
                string iconoUsu = Path.Combine(Server.MapPath("~/Content/Uploads/User_icons"), idUsu);

                if ((System.IO.File.Exists(iconoUsu + ".jpg")))
                {
                    model.User_Icon = model.Id + ".jpg";
                }
                else if ((System.IO.File.Exists(iconoUsu + ".jpeg")))
                {
                    model.User_Icon = model.Id + ".jpeg";
                }
                else if ((System.IO.File.Exists(iconoUsu + ".png")))
                {
                    model.User_Icon = model.Id + ".png";
                }
                else if ((System.IO.File.Exists(iconoUsu + ".gif")))
                {
                    model.User_Icon = model.Id + ".gif";
                }
                else
                {
                    //SI NO TIENE FOTO DE PERFIL
                    model.User_Icon = "";
                }

                SessionClose();

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("../Home");
            }
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
        public ActionResult Create(HttpPostedFileBase file, Registrado reg)
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

                //SUBIDA DE LA FOTO
                var path = "";

                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        //PARA UTILIZAR PATH SE NECESITA using System.IO
                        if (    (Path.GetExtension(file.FileName).ToLower() == ".jpg") || (Path.GetExtension(file.FileName).ToLower() == ".png") || 
                                (Path.GetExtension(file.FileName).ToLower() == ".gif") || (Path.GetExtension(file.FileName).ToLower() == ".jpeg")   )
                        {
                            path = Path.Combine(Server.MapPath("~/Content/Uploads/User_icons"), usuSingUp.Id+Path.GetExtension(file.FileName).ToLower());
                            file.SaveAs(path);

                        }

                    }
                }


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
        public ActionResult Edit(Models.Registrado reg)
        {
            try
            {
                int regId = (int)Session["idUsuario"];

                RegistradoCAD registradoCAD = new RegistradoCAD();
                RegistradoCEN registradoCEN = new RegistradoCEN();
                RegistradoEN  registradoEN  = registradoCEN.get_IRegistradoCAD().ReadOIDDefault(regId);

                if (reg.Nombre != null) registradoEN.Nombre = reg.Nombre;
                if (reg.Apellidos != null) registradoEN.Apellidos = reg.Apellidos;
                if (reg.Edad != 0) registradoEN.Edad = reg.Edad;
                if (reg.Dni != null) registradoEN.Dni = reg.Dni;
                if (reg.FNacimiento != null) registradoEN.Fecha_nac = reg.FNacimiento;

                if (reg.Contrasenya != null) registradoEN.Contrasenya = reg.Contrasenya;

                registradoCAD.Modify(registradoEN);

                return RedirectToAction("../Registrado/Perfil", new { id = regId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Registrado/Delete/5
        public ActionResult Delete(int id)
        {
            RegistradoCEN registradoCEN = new RegistradoCEN();

            registradoCEN.Destroy(id);

            IList<RegistradoEN> registrados = registradoCEN.get_IRegistradoCAD().ReadAll(0, -1);
            Admin art = new AssemblerRegistrado().Conversion(registrados);

            return View("Admin", art);
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

        public ActionResult Admin()
        {

            ArticuloCEN articuloCEN = new ArticuloCEN();
            RegistradoCEN registradoCEN = new RegistradoCEN();

            IList<RegistradoEN> registrados = registradoCEN.get_IRegistradoCAD().ReadAll(0, -1);

            Admin art = new AssemblerRegistrado().Conversion(registrados);

            return View(art);
        }

        public ActionResult Beater(int id, bool ad)
        {
            RegistradoCEN registradoCEN = new RegistradoCEN();

            registradoCEN.Convertir_usuario(id, ad);

            if(!ad && id == (int)Session["idUsuario"])
            {
                System.Web.HttpContext.Current.Session.Remove("admin");
            }

            IList<RegistradoEN> registrados = registradoCEN.get_IRegistradoCAD().ReadAll(0, -1);

            Admin art = new AssemblerRegistrado().Conversion(registrados);

            return View("Admin", art);
        }

        [HttpPost]
        public ActionResult NewPass(String antigua, String nueva, String repe)
        {
            try
            {
                int regId = (int)Session["idUsuario"];

                RegistradoCAD registradoCAD = new RegistradoCAD();
                RegistradoCEN registradoCEN = new RegistradoCEN();
                RegistradoEN registradoEN = registradoCEN.get_IRegistradoCAD().ReadOIDDefault(regId);

                String encrip = Util.GetEncondeMD5(antigua);

                if (nueva == repe)
                {
                    if (registradoEN.Contrasenya == encrip)
                    {
                        registradoEN.Contrasenya = encrip;
                    }
                    else
                    {
                        //ANTIGUA INCORRECTA
                    }
                }
                else
                {
                    //LAS NUEVAS DEBEN COINCIDIR
                }

                registradoCAD.Modify(registradoEN);

                return RedirectToAction("../Registrado/Perfil", new { id = regId });
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult NewPersonales(Models.Registrado reg)
        {
            try
            {
                int regId = (int)Session["idUsuario"];

                RegistradoCAD registradoCAD = new RegistradoCAD();
                RegistradoCEN registradoCEN = new RegistradoCEN();
                RegistradoEN registradoEN = registradoCEN.get_IRegistradoCAD().ReadOIDDefault(regId);

                registradoEN.Nombre = reg.Nombre;
                registradoEN.Apellidos = reg.Apellidos;
                registradoEN.Edad = reg.Edad;
                registradoEN.Dni = reg.Dni;

                registradoCAD.Modify(registradoEN);

                return RedirectToAction("../Registrado/Perfil", new { id = regId });
            }
            catch
            {
                return View();
            }
        }

    }
}
