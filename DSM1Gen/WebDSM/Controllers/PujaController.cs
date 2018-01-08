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
        public ActionResult Create(int Articulo, float Puja)
        {
            try
            {
                bool repetido = false;
                PujaCEN pujaCEN = new PujaCEN();
                IList<PujaEN> pujas = pujaCEN.ReadAll(0, -1);
                foreach (var item in pujas)
                {
                    if(item.Articulo.Id == Articulo)
                    {
                        repetido = true;
                        break;
                    }
                }
                pujaCEN.New_(DateTime.Now, Puja, Articulo, Puja, -1, false, false);

                /*
                if (!repetido)
                {
                    
                }
                else
                {
                    System.Web.HttpContext.Current.Session["PujaError"] = "Repetida";
                    return RedirectToAction("../Registrado/Admin");
                }
                */

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
        public ActionResult Edit(Models.Admin puj)
        {
            try
            {
                PujaCEN pujaCEN = new PujaCEN();
                

                pujaCEN.New_(DateTime.Now, puj.Puja.PujaInicial, puj.Puja.Id, puj.Puja.PujaInicial, -1, false, false);
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

        [HttpPost]
        [AllowAnonymous]

        public ActionResult NuevaPuja(float puja, int id)
        {
            if(puja == 0)
            {
                System.Web.HttpContext.Current.Session["PujaError"] = "Introduce un importe";
                return RedirectToAction("Details/" + id);
            }
            try
            {
                SessionInitialize();

                OfertaPujaCAD ofertaPujaCAD = new OfertaPujaCAD(session);
                OfertaPujaCEN ofertaPujaCEN = new OfertaPujaCEN(ofertaPujaCAD);

                OfertaPujaCP ofertaPujaCP = new OfertaPujaCP();

                ofertaPujaCP.Nueva_oferta(DateTime.Now, DateTime.Now, (int)Session["idUsuario"], id, puja); //Nueva oferta 
                SessionClose();
                
                return RedirectToAction("Details/"+id);
            }
            catch(Exception e)
            {
                System.Web.HttpContext.Current.Session["PujaError"] = e.Message;
                
                return RedirectToAction("Details/"+id);
            }
        }

        [HttpPost]
        [AllowAnonymous]

        public ActionResult Cierra(int id)
        {
            try
            {
                PujaCEN pujaCEN = new PujaCEN();
                PujaEN pujaEN = pujaCEN.get_IPujaCAD().ReadOIDDefault(id);

                PujaCP pujaCP = new PujaCP();

                pujaCP.Terminar_puja(id, DateTime.Now, pujaEN.Puja_inicial, pujaEN.Puja_max, pujaEN.Id_usuario, true, false);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                System.Web.HttpContext.Current.Session["PujaError"] = e.Message;
                return RedirectToAction("../Registrado/Admin");
            }
        }

        public ActionResult PagarPuja(int pujaid)
        {
            int usuid = (int)Session["idusuario"];

            PujaCAD pujaCAD = new PujaCAD();
            PujaCEN pujaCEN = new PujaCEN();
            PujaEN pujaEN = pujaCEN.get_IPujaCAD().ReadOIDDefault(pujaid);

            LineaPedidoCAD lineaCAD = new LineaPedidoCAD();
            LineaPedidoCEN lineaCEN = new LineaPedidoCEN();
            int lineaID = lineaCEN.New_(1 , pujaEN.Articulo.Id);

            List<int> lineasList = new List<int>
            {
                lineaID
            };

            PedidoCAD pedidoCAD = new PedidoCAD();
            PedidoCEN pedidoCEN = new PedidoCEN();
            int pedidoID = pedidoCEN.New_("Pedido de puja", DateTime.Now, usuid);

            pedidoCEN.Anyadir_linea(pedidoID, lineasList);

            //pujaEN.Pagada = true;

            pujaCEN.Modify(pujaEN.Id, pujaEN.Fecha, pujaEN.Puja_inicial, pujaEN.Puja_max, pujaEN.Id_usuario, pujaEN.Cerrada, true);
            

            return RedirectToAction("Details/" + pujaid);
        }

        public ActionResult LoadGanadas()
        {
            try
            {
                SessionInitialize();

                RegistradoCAD registradoCAD = new RegistradoCAD(session);
                RegistradoCEN registradoCEN = new RegistradoCEN(registradoCAD);

                PujaCAD pujaCAD = new PujaCAD(session);
                PujaCEN pujaCEN = new PujaCEN(pujaCAD);

                int miID = (int)Session["idUsuario"];
                RegistradoEN registradoEN = registradoCEN.get_IRegistradoCAD().ReadOIDDefault(miID);

                IList<PujaEN> pujasEN = registradoEN.PujaGanadora;
                IEnumerable<Puja> pujas = new AssemblerPuja().ConvertListENToModel(pujasEN);

                SessionClose();

                return View("../Registrado/Ganadas", pujas);
            }
            catch (Exception e)
            {
                return RedirectToAction("../Home");
            }
        }
    }
}
